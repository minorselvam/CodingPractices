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
# Step 1: Create and Deploy Order Service YAML
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
  replicas: 1
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
        image: testmskacr.azurecr.io/orderservice:v1
        imagePullPolicy: IfNotPresent
        ports:
        - containerPort: 8080
        resources:
          requests:
            cpu: "100m"
            memory: "128Mi"
          limits:
            cpu: "500m"
            memory: "512Mi"
        livenessProbe:
          httpGet:
            path: /health/live
            port: 8080
          initialDelaySeconds: 30
          periodSeconds: 20
          failureThreshold: 3
        readinessProbe:
          httpGet:
            path: /health/ready
            port: 8080
          initialDelaySeconds: 10
          periodSeconds: 10
          failureThreshold: 3
EOF

echo ">>> Deploying Order Service..."
kubectl apply -f orderapi-deployment.yaml
kubectl expose deployment orderapi-deployment --type=LoadBalancer --name=orderapi-service --port=8080 --target-port=8080
kubectl get service orderapi-service
echo "Expected Result: Service orderapi-service with EXTERNAL-IP assigned."

echo "============================================================"
echo "Order Service Deployment Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
