FROM dockerhub.dttt.vn/aspnetcore-with-grpc:5.0
COPY ./bin/Release/netcoreapp5.0/publish /app
ENV SCOPE__SERVICE=nganhangcauhoi
ENTRYPOINT ["dotnet", "NganHangCauHoi.API.dll"]
