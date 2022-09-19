#!/bin/bash

docker-compose -f docker-compose.yml up -d

cd ../../Terraform/DEV/Vault

terraform apply -auto-approve

cd ../../../Application/Starlight

docker-compose -f API/docker-compose-migrations.yml up -d

docker-compose -f API/docker-compose-debug.yml up -d

