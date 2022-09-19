docker-compose build
docker-compose push 

docker-compose -f docker-compose-migrations.yml build
docker-compose -f docker-compose-migrations.yml push 