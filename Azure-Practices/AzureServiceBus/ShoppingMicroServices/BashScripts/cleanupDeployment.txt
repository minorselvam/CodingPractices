#!/bin/bash
set -e  # Exit immediately if a command fails

# ============================================================
# Logging Setup
# ============================================================
LOGFILE="CleanupDeployment_$(date +%Y%m%d_%H%M%S).log"
exec > >(tee -a "$LOGFILE") 2>&1

echo "============================================================"
echo "Cleanup of Deployment started at $(date)"
echo "Logs will be saved to $LOGFILE"
echo "============================================================"

# Step 1: Delete Kubernetes Services
echo ">>> Deleting Services..."
kubectl delete service orderapi-service --ignore-not-found
kubectl delete service paymentapi-service --ignore-not-found
kubectl delete service shippingapi-service --ignore-not-found

# Step 2: Delete Kubernetes Deployments
echo ">>> Deleting Deployments..."
kubectl delete deployment orderapi-deployment --ignore-not-found
kubectl delete deployment paymentservice-deployment --ignore-not-found
kubectl delete deployment shippingservice-deployment --ignore-not-found

# Step 3: Delete Kubernetes Secret
echo ">>> Deleting Secret..."
kubectl delete secret servicebus-secret --ignore-not-found

# Step 4: Remove YAML files (optional cleanup)
echo ">>> Removing YAML files..."
rm -f orderapi-deployment.yaml payment-deployment.yaml shipping-deployment.yaml

# Step 5: Delete Service Bus Namespace
echo ">>> Deleting Service Bus Namespace..."
az servicebus namespace delete --resource-group TestMskRsGrp --name TestMskServBs || true

echo "============================================================"
echo "Cleanup of Deployment Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
