docker-compose build
docker-compose push 

dotnet ef migrations bundle --self-contained -r linux-x64 --verbose --configuration Bundle

docker-compose -f docker-compose-migrations.yml build
docker-compose -f docker-compose-migrations.yml push 