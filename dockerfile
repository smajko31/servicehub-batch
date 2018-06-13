# STAGE - BUILD
FROM microsoft/aspnetcore-build:2.0 as build
WORKDIR /docker
COPY src/ServiceHub.Batch.Context/*.csproj ServiceHub.Batch.Context/
COPY src/ServiceHub.Batch.Library/*.csproj ServiceHub.Batch.Library/
COPY src/ServiceHub.Batch.Service/*.csproj ServiceHub.Batch.Service/
RUN dotnet restore *.Service
COPY src ./
RUN dotnet publish *.Service --no-restore -o ../www

# STAGE - DEPLOY
FROM microsoft/aspnetcore:2.0 as deploy
WORKDIR /webapi
COPY --from=build /docker/www ./
ENV ASPNETCORE_URLS=http://+:80/
EXPOSE 80
CMD [ "dotnet", "ServiceHub.Batch.Service.dll" ]
