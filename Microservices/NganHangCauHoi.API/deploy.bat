@echo off

dotnet publish -c Release -o bin/Release/netcoreapp5.0/publish
docker build -f Dockerfile -t dockerhub.dttt.vn/u2205/nganhangcauhoi.api:5.2 .
docker push dockerhub.dttt.vn/u2205/nganhangcauhoi.api:5.2
PAUSE
