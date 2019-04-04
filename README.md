# DockerDemo
Aplicación MVC con docker


Comandos

docker-compose up -d

docker image rm c60b4aadbdcf

docker container ls

docker image save docker2019:1 -o docker2019.tar

docker image ls

docker image tag docker2019:1 docker2019:2

docker image build . -t docker2019:1

docker container run -d -p 80:80 nginx:1.14.2
