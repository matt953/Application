#!/bin/bash

docker-compose -f docker-compose.yml up -d

cd ../../Terraform/DEV/Vault

terraform apply -auto-approve

cd ../../../Application/Starlight/API

dotnet ef migrations bundle --self-contained -r linux-x64 --verbose --configuration Bundle

cd ../../../Application/Starlight

docker-compose -f API/docker-compose-migrations.yml up -d

docker-compose -f API/docker-compose.yml up -d

