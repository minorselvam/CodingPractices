 
#!/bin/bash
set -e  # Exit immediately if a command fails

# ============================================================
# Logging Setup
# ============================================================
LOGFILE="Testing_$(date +%Y%m%d_%H%M%S).log"
exec > >(tee -a "$LOGFILE") 2>&1

echo "============================================================"
echo "Deployment started at $(date)"
echo "Logs will be saved to $LOGFILE"
echo "============================================================"

# ============================================================
# Step 1: Retrieve External IP for Order API Service
# ============================================================
echo ">>> Retrieving External IP for Order API Service..."
ORDER_IP=$(kubectl get service orderapi-service -o jsonpath='{.status.loadBalancer.ingress[0].ip}')
echo "Order API External IP: $ORDER_IP"
echo "Expected Result: A valid external IP address printed."

# ============================================================
# Step 2: End-to-End Test Sequence
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
echo "End-to-End Test Completed Successfully at $(date)"
echo "Logs saved to $LOGFILE"
echo "============================================================"
