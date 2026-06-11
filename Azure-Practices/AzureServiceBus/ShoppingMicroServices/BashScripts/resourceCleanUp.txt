#!/bin/bash
set -e

LOGFILE="resourceCleanup_$(date +%Y%m%d_%H%M%S).log"
exec > >(tee -a "$LOGFILE") 2>&1

echo "Starting cleanup at $(date)"

# Delete resource group
az group delete --name TestMskRsGrp --yes --no-wait

echo "Resource cleanup initiated. Monitor Azure Portal or run 'az group show' to confirm deletion."
