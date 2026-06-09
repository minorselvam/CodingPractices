 
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
  // Schema reference for ARM template validation

  "contentVersion": "1.0.0.0", 
  // Version of this template (for tracking changes)

  "resources": [ 
    // List of resources to be deployed in Azure

    {
      "type": "Microsoft.ContainerService/managedClusters", 
      // Resource type: creates an AKS (Azure Kubernetes Service) cluster

      "apiVersion": "2023-08-01", 
      // API version used for AKS resource creation

      "name": "TestMskAKS", 
      // Name of the AKS cluster

      "location": "southindia", 
      // Azure region where the cluster will be deployed

      "identity": { "type": "SystemAssigned" }, 
      // Enables a system-assigned managed identity for secure resource access

      "sku": { "name": "Base", "tier": "Free" }, 
      // Pricing tier for AKS (Base/Free tier)

      "properties": { 
        // Cluster configuration details

        "dnsPrefix": "TestMskAKS-dns", 
        // DNS prefix for the cluster API server endpoint

        "agentPoolProfiles": [ 
          // Defines the node pool (worker nodes) for the cluster

          {
            "name": "agentpool", 
            // Name of the node pool

            "count": 1, 
            // Initial number of nodes in the pool

            "vmSize": "Standard_B2s", 
            // VM size for each node (CPU/memory capacity)

            "osType": "Linux", 
            // Operating system for nodes (Linux)

            "mode": "System", 
            // Marks this pool as the system node pool (required for AKS)

            "enableAutoScaling": true, 
            // Enables autoscaling for nodes

            "minCount": 0, 
            // Minimum number of nodes allowed in autoscaling

            "maxCount": 2 
            // Maximum number of nodes allowed in autoscaling
          }
        ],

        "enableRBAC": true, 
        // Enables Role-Based Access Control (RBAC) for cluster security

        "networkProfile": { 
          // Networking configuration for the cluster

          "networkPlugin": "azure", 
          // Uses Azure CNI plugin for networking (pods get Azure IPs)

          "loadBalancerSku": "Standard", 
          // Type of load balancer (Standard supports advanced features)

          "serviceCidr": "10.0.0.0/16", 
          // IP range for Kubernetes services

          "dnsServiceIP": "10.0.0.10", 
          // IP address for the cluster DNS service

          "podCidr": "10.244.0.0/16" 
          // IP range for pods in the cluster
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
