FROM microsoft/dotnet:2.0-sdk as build
WORKDIR /docker
COPY ./src .
RUN dotnet build ServiceHub.Batch.sln

FROM microsoft/aspnetcore:2.0 as deploy
WORKDIR /webapi
COPY --from=build /docker/ServiceHub.Batch.Service/bin/Debug/netcoreapp2.0/ .
ENV ASPNETCORE_URLS=http://+:80/
EXPOSE 80
CMD [ "dotnet", "ServiceHub.Batch.Service.dll" ]
