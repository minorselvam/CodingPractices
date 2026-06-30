#!/bin/bash
set -e  # Exit immediately if a command fails

# ============================================================
# Logging Setup
# ============================================================
LOGFILE="resourceCreation_$(date +%Y%m%d_%H%M%S).log"
exec > >(tee -a "$LOGFILE") 2>&1

echo "============================================================"
echo "Deployment started at $(date)"
echo "Logs will be saved to $LOGFILE"
echo "============================================================"

# ============================================================
# Variables
# ============================================================
RESOURCE_GROUP="TestMskRsGrp"
LOCATION="southindia"
ACR_NAME="TestMskACR"
AKS_NAME="TestMskAKS"
EVENTHUB_NAMESPACE="TestMskEvHbNs"
EVENTHUB_NAME="TestMskEvHb"
EVENTHUB_SKU="Standard"   # Standard or Dedicated required for Kafka
EVENTHUB_PARTITIONS=2

# ============================================================
# Step 1: Create Resource Group
# ============================================================
echo ">>> Creating Resource Group..."
az group create --name $RESOURCE_GROUP --location $LOCATION
echo ">>> Verifying Resource Group..."
az group show --name $RESOURCE_GROUP --output table
echo "Expected Result: Resource group $RESOURCE_GROUP listed with location $LOCATION."

# ============================================================
# Step 2: Create ACR JSON file and Deploy
# ============================================================
echo ">>> Creating acr-template.json..."
cat <<EOF > acr-template.json
{
  "\$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "resources": [
    {
      "type": "Microsoft.ContainerRegistry/registries",
      "apiVersion": "2023-01-01-preview",
      "name": "$ACR_NAME",
      "location": "$LOCATION",
      "sku": { "name": "Basic" },
      "properties": {
        "adminUserEnabled": false,
        "publicNetworkAccess": "Enabled"
      }
    }
  ]
}
EOF
echo ">>> Deploying ACR..."
az deployment group create --resource-group $RESOURCE_GROUP --template-file acr-template.json
echo ">>> Verifying ACR..."
az acr show --name $ACR_NAME --resource-group $RESOURCE_GROUP --output table
echo "Expected Result: ACR $ACR_NAME listed with SKU Basic."

# ============================================================
# Step 3: Create AKS JSON file and Deploy
# ============================================================
echo ">>> Creating aks-template.json..."
cat <<EOF > aks-template.json
{
  "\$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#", 
  "contentVersion": "1.0.0.0", 
  "resources": [ 
    {
      "type": "Microsoft.ContainerService/managedClusters", 
      "apiVersion": "2023-08-01", 
      "name": "$AKS_NAME", 
      "location": "$LOCATION", 
      "identity": { "type": "SystemAssigned" }, 
      "sku": { "name": "Base", "tier": "Free" }, 
      "properties": { 
        "dnsPrefix": "$AKS_NAME-dns", 
        "agentPoolProfiles": [ 
          {
            "name": "agentpool", 
            "count": 1, 
            "vmSize": "Standard_B2s", 
            "osType": "Linux", 
            "mode": "System", 
            "enableAutoScaling": true, 
            "minCount": 0, 
            "maxCount": 2 
          }
        ],
        "enableRBAC": true, 
        "networkProfile": { 
          "networkPlugin": "azure", 
          "loadBalancerSku": "Standard", 
          "serviceCidr": "10.0.0.0/16", 
          "dnsServiceIP": "10.0.0.10", 
          "podCidr": "10.244.0.0/16" 
        }
      }
    }
  ]
}
EOF
echo ">>> Deploying AKS..."
az deployment group create --resource-group $RESOURCE_GROUP --template-file aks-template.json
echo ">>> Verifying AKS..."
az aks show --name $AKS_NAME --resource-group $RESOURCE_GROUP --output table
echo "Expected Result: AKS cluster $AKS_NAME listed with agent pool agentpool."

# ============================================================
# Step 4: Attach ACR to AKS
# ============================================================
echo ">>> Attaching ACR to AKS..."
az aks update --resource-group $RESOURCE_GROUP --name $AKS_NAME --attach-acr $ACR_NAME
echo "Expected Result: AKS cluster shows ACR attached."

# ============================================================
# Step 5: Connect to AKS
# ============================================================
echo ">>> Connecting to AKS..."
az aks get-credentials --resource-group $RESOURCE_GROUP --name $AKS_NAME
kubectl get nodes
echo "Expected Result: Nodes listed in Ready state."

# ============================================================
# Step 6: Create Event Hub Namespace (Kafka enabled)
# ============================================================
echo ">>> Creating Event Hub Namespace with Kafka enabled..."
az eventhubs namespace create \
  --name $EVENTHUB_NAMESPACE \
  --resource-group $RESOURCE_GROUP \
  --location $LOCATION \
  --sku $EVENTHUB_SKU \
  --enable-kafka true
echo ">>> Verifying Event Hub Namespace..."
az eventhubs namespace show --name $EVENTHUB_NAMESPACE --resource-group $RESOURCE_GROUP --output table
echo "Expected Result: Event Hub namespace $EVENTHUB_NAMESPACE listed with Kafka enabled."

# ============================================================
# Step 7: Create Event Hub
# ============================================================
echo ">>> Creating Event Hub..."
az eventhubs eventhub create \
  --name $EVENTHUB_NAME \
  --resource-group $RESOURCE_GROUP \
  --namespace-name $EVENTHUB_NAMESPACE \
  --partition-count $EVENTHUB_PARTITIONS
echo ">>> Verifying Event Hub..."
az eventhubs eventhub show --name $EVENTHUB_NAME --resource-group $RESOURCE_GROUP --namespace-name $EVENTHUB_NAMESPACE --output table
echo "Expected Result: Event Hub $EVENTHUB_NAME listed with $EVENTHUB_PARTITIONS partitions."

# ============================================================
# Step 8: Create Authorization Rule
# ============================================================
echo ">>> Creating Authorization Rule..."
az eventhubs namespace authorization-rule create \
  --resource-group $RESOURCE_GROUP \
  --namespace-name $EVENTHUB_NAMESPACE \
  --name "SendListenPolicy" \
  --rights Send Listen Manage
echo "Expected Result: Authorization rule SendListenPolicy created with Send/Listen/Manage rights."

echo "============================================================"
echo "Resource creation Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
