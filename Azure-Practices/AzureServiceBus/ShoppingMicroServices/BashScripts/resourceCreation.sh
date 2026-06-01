 
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
# Step 1: Create Resource Group
# ============================================================
echo ">>> Creating Resource Group..."
az group create --name TestMskRsGrp --location southindia
echo ">>> Verifying Resource Group..."
az group show --name TestMskRsGrp --output table
echo "Expected Result: Resource group TestMskRsGrp listed with location southindia."

# ============================================================
# Step 2: Create ACR JSON file and Deploy
# ============================================================
echo ">>> Creating acr-template.json..."
cat <<'EOF' > acr-template.json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "resources": [
    {
      "type": "Microsoft.ContainerRegistry/registries",
      "apiVersion": "2023-01-01-preview",
      "name": "TestMskACR",
      "location": "southindia",
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
az deployment group create --resource-group TestMskRsGrp --template-file acr-template.json
echo ">>> Verifying ACR..."
az acr show --name TestMskACR --resource-group TestMskRsGrp --output table
echo "Expected Result: ACR TestMskACR listed with SKU Basic."

# ============================================================
# Step 3: Create AKS JSON file and Deploy
# ============================================================
echo ">>> Creating aks-template.json..."
cat <<'EOF' > aks-template.json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "resources": [
    {
      "type": "Microsoft.ContainerService/managedClusters",
      "apiVersion": "2023-08-01",
      "name": "TestMskAKS",
      "location": "southindia",
      "identity": { "type": "SystemAssigned" },
      "sku": { "name": "Base", "tier": "Free" },
      "properties": {
        "dnsPrefix": "TestMskAKS-dns",
        "agentPoolProfiles": [
          {
            "name": "agentpool",
            "count": 2,
            "vmSize": "Standard_D4ds_v5",
            "osType": "Linux",
            "mode": "System",
            "enableAutoScaling": true,
            "minCount": 2,
            "maxCount": 5
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
az deployment group create --resource-group TestMskRsGrp --template-file aks-template.json
echo ">>> Verifying AKS..."
az aks show --name TestMskAKS --resource-group TestMskRsGrp --output table
echo "Expected Result: AKS cluster TestMskAKS listed with agent pool agentpool."

# ============================================================
# Step 4: Attach ACR to AKS
# ============================================================
echo ">>> Attaching ACR to AKS..."
az aks update --resource-group TestMskRsGrp --name TestMskAKS --attach-acr TestMskACR
echo "Expected Result: AKS cluster shows ACR attached."

# ============================================================
# Step 5: Connect to AKS
# ============================================================
echo ">>> Connecting to AKS..."
az aks get-credentials --resource-group TestMskRsGrp --name TestMskAKS
kubectl get nodes
echo "Expected Result: Two nodes listed in Ready state."

# ============================================================
# Step 6: Create Service Bus JSON file and Deploy
# ============================================================
echo ">>> Creating servicebus.json..."
cat <<'EOF' > servicebus.json
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "resources": [
    {
      "apiVersion": "2025-05-01-preview",
      "name": "TestMskServBs",
      "type": "Microsoft.ServiceBus/namespaces",
      "sku": { "name": "Basic", "tier": "Basic" },
      "location": "southindia",
      "properties": {
        "minimumTlsVersion": "1.2",
        "publicNetworkAccess": "Enabled",
        "disableLocalAuth": false,
        "zoneRedundant": false
      }
    }
  ]
}
EOF
echo ">>> Deploying Service Bus..."
az deployment group create --resource-group TestMskRsGrp --template-file servicebus.json
echo ">>> Verifying Service Bus..."
az servicebus namespace show --name TestMskServBs --resource-group TestMskRsGrp --output table
echo "Expected Result: Namespace TestMskServBs listed with SKU Basic."

# ============================================================
# Step 7: Create Queues
# ============================================================
echo ">>> Creating Service Bus Queues..."
az servicebus queue create --resource-group TestMskRsGrp --namespace-name TestMskServBs --name OrderQueue
az servicebus queue create --resource-group TestMskRsGrp --namespace-name TestMskServBs --name PaymentQueue
az servicebus queue create --resource-group TestMskRsGrp --namespace-name TestMskServBs --name ShippingQueue
az servicebus queue list --resource-group TestMskRsGrp --namespace-name TestMskServBs --output table
echo "Expected Result: Queues OrderQueue, PaymentQueue, and ShippingQueue listed."

echo "============================================================"
echo "Resource creation Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
