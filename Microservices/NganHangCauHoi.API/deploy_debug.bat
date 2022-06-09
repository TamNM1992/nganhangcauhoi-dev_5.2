

@echo off

docker pull dockerhub.dttt.vn/aspnetcore:5.0-debug
dotnet publish -c Debug -o bin/Debug/netcoreapp5.0/publish_debug
docker build -f Dockerfile.debug -t dockerhub.dttt.vn/core/nganhangcauhoi.api:5.2-debug .
docker push dockerhub.dttt.vn/core/nganhangcauhoi.api:5.2-debug