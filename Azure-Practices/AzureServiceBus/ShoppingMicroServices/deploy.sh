 
#!/bin/bash
set -e  # Exit immediately if a command fails

# ============================================================
# Logging Setup
# ============================================================
LOGFILE="deploy_$(date +%Y%m%d_%H%M%S).log"
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

# ============================================================
# Step 8: Get Service Bus Connection String
# ============================================================
echo ">>> Retrieving Service Bus Connection String..."
CONN_STR=$(az servicebus namespace authorization-rule keys list \
  --resource-group TestMskRsGrp \
  --namespace-name TestMskServBs \
  --name RootManageSharedAccessKey \
  --query primaryConnectionString -o tsv)
echo "Expected Result: Full connection string printed."

# ============================================================
# Step 9: Create Kubernetes Secret
# ============================================================
echo ">>> Creating Kubernetes Secret..."
kubectl create secret generic servicebus-secret --from-literal=AzureServiceBus="$CONN_STR"
echo "Expected Result: Secret servicebus-secret created."

# ============================================================
# Step 10: Create and Deploy Order Service YAML
# ============================================================
echo ">>> Creating orderapi-deployment.yaml..."
cat <<'EOF' > orderapi-deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: orderapi-deployment
  labels:
    app: orderapi
spec:
  replicas: 2
  selector:
    matchLabels:
      app: orderapi
  template:
    metadata:
      labels:
        app: orderapi
    spec:
      containers:
      - name: orderapi
        image: testmskacr.azurecr.io/orderservice:v2
        ports:
        - containerPort: 8080
        env:
        - name: AzureServiceBus
          valueFrom:
            secretKeyRef:
              name: servicebus-secret
              key: AzureServiceBus
EOF

echo ">>> Deploying Order Service..."
kubectl apply -f orderapi-deployment.yaml
kubectl expose deployment orderapi-deployment --type=LoadBalancer --name=orderapi-service --port=8080 --target-port=8080
kubectl get service orderapi-service
echo "Expected Result: Service orderapi-service with EXTERNAL-IP assigned."

# ============================================================
# Step 11: Create and Deploy Payment Service YAML
# ============================================================
echo ">>> Creating payment-deployment.yaml..."
cat <<'EOF' > payment-deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: paymentservice-deployment
  labels:
    app: paymentservice
spec:
  replicas: 2
  selector:
    matchLabels:
      app: paymentservice
  template:
    metadata:
      labels:
        app: paymentservice
    spec:
      containers:
      - name: paymentservice
        image: testmskacr.azurecr.io/paymentservice:v1
        ports:
        - containerPort: 8080
        env:
        - name: AzureServiceBus
          valueFrom:
            secretKeyRef:
              name: servicebus-secret
              key: AzureServiceBus
---
apiVersion: v1
kind: Service
metadata:
  name: paymentapi-service
spec:
  type: ClusterIP
  selector:
    app: paymentservice
  ports:
  - port: 8080
    targetPort: 8080
EOF

echo ">>> Deploying Payment Service..."
kubectl apply -f payment-deployment.yaml
kubectl get service paymentapi-service
echo "Expected Result: Service paymentapi-service with ClusterIP assigned (internal only)."

# ============================================================
# Step 12: Create and Deploy Shipping Service YAML
# ============================================================
echo ">>> Creating shipping-deployment.yaml..."
cat <<'EOF' > shipping-deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: shippingservice-deployment
  labels:
    app: shippingservice
spec:
  replicas: 2
  selector:
    matchLabels:
      app: shippingservice
  template:
    metadata:
      labels:
        app: shippingservice
    spec:
      containers:
      - name: shippingservice
        image: testmskacr.azurecr.io/shippingservice:v1
        ports:
        - containerPort: 8080
        env:
        - name: AzureServiceBus
          valueFrom:
            secretKeyRef:
              name: servicebus-secret
              key: AzureServiceBus
---
apiVersion: v1
kind: Service
metadata:
  name: shippingapi-service
spec:
  type: ClusterIP
  selector:
    app: shippingservice
  ports:
  - port: 8080
    targetPort: 8080
EOF

echo ">>> Deploying Shipping Service..."
kubectl apply -f shipping-deployment.yaml
kubectl get service shippingapi-service
echo "Expected Result: Service shippingapi-service with ClusterIP assigned (internal only)."

# ============================================================
# Step 13: Verify All Deployments
# ============================================================
echo ">>> Verifying all deployments..."
kubectl get deployments
kubectl get pods
kubectl get services
echo "Expected Result: Order, Payment, and Shipping services all running with correct endpoints."

# ============================================================
# Step 14: Retrieve External IP for Order API Service
# ============================================================
echo ">>> Retrieving External IP for Order API Service..."
ORDER_IP=$(kubectl get service orderapi-service -o jsonpath='{.status.loadBalancer.ingress[0].ip}')
echo "Order API External IP: $ORDER_IP"
echo "Expected Result: A valid external IP address printed."

# ============================================================
# Step 15: End-to-End Test Sequence
# ============================================================
echo ">>> Testing Order → Payment → Shipping flow..."

# Place an order using the retrieved IP
curl http://$ORDER_IP:8080/api/order/place \
  -H "Content-Type: application/json" \
  -d '{"Id":"test-order-123","Product":"Test Order"}'

echo "Expected Result: Response confirms order placed with Id test-order-123."

# Verify PaymentService logs
echo ">>> Checking PaymentService logs..."
kubectl logs -l app=paymentservice --tail=20
echo "Expected Result: Log shows 'Payment processed for Order test-order-123'."

# Verify ShippingService logs
echo ">>> Checking ShippingService logs..."
kubectl logs -l app=shippingservice --tail=20
echo "Expected Result: Log shows 'Shipping started for Order test-order-123'."

# Verify OrderService logs
echo ">>> Checking OrderService logs..."
kubectl logs -l app=orderapi --tail=20
echo "Expected Result: Log shows 'Order test-order-123 marked as shipped!'."

echo "============================================================"
echo "Deployment and End-to-End Test Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
