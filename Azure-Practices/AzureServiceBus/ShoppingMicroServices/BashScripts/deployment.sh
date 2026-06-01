 
#!/bin/bash
set -e  # Exit immediately if a command fails

# ============================================================
# Logging Setup
# ============================================================
LOGFILE="Deployment_$(date +%Y%m%d_%H%M%S).log"
exec > >(tee -a "$LOGFILE") 2>&1

echo "============================================================"
echo "Deployment started at $(date)"
echo "Logs will be saved to $LOGFILE"
echo "============================================================"

# ============================================================
# Step 1: Get Service Bus Connection String
# ============================================================
echo ">>> Retrieving Service Bus Connection String..."
CONN_STR=$(az servicebus namespace authorization-rule keys list \
  --resource-group TestMskRsGrp \
  --namespace-name TestMskServBs \
  --name RootManageSharedAccessKey \
  --query primaryConnectionString -o tsv)
echo "Expected Result: Full connection string printed."

# ============================================================
# Step 2: Create Kubernetes Secret
# ============================================================
echo ">>> Creating Kubernetes Secret..."
kubectl create secret generic servicebus-secret --from-literal=AzureServiceBus="$CONN_STR"
echo "Expected Result: Secret servicebus-secret created."

# ============================================================
# Step 3: Create and Deploy Order Service YAML
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
# Step 4: Create and Deploy Payment Service YAML
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
# Step 5: Create and Deploy Shipping Service YAML
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
# Step 6: Verify All Deployments
# ============================================================
echo ">>> Verifying all deployments..."
kubectl get deployments
kubectl get pods
kubectl get services
echo "Expected Result: Order, Payment, and Shipping services all running with correct endpoints."

echo "============================================================"
echo "Deployment of the Services Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
