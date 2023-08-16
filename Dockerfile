# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /app

# COPY ClientManager.Domain.Api/*.csproj ClientManager.Domain.Api/
# COPY ClientManager.Domain.Infra/*.csproj ClientManager.Domain.Infra/
# COPY ClientManager.Domain/*.csproj ClientManager.Domain/
# COPY ClientManager.Domain.Tests/*.csproj ClientManager.Domain.Tests/

# COPY *.sln ClientManager.sln

# RUN dotnet restore

# COPY . .

# RUN dotnet build -c Release --no-restore

# RUN dotnet publish ClientManager.Domain.Api/ClientManager.Domain.Api.csproj -c Release -o out --no-restore

# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# FROM build AS publish
# RUN dotnet publish "ClientManager.Domain.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# # FROM base AS final
# # WORKDIR /app
# # COPY --from=publish /app/publish .
# # ENTRYPOINT ["dotnet", "ClientManager.Domain.Api.dll"]



# WORKDIR /app

# # Copy the published output from the previous stage
# COPY --from=build /app/ClientManager.Domain.Api/out .

# # Expose the port that the application will listen on
# EXPOSE 80

# # Start the application
# ENTRYPOINT ["dotnet", "ClientManager.Domain.Api.dll"]


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY ClientManager.Domain.Api/*.csproj ClientManager.Domain.Api/
COPY ClientManager.Domain.Infra/*.csproj ClientManager.Domain.Infra/
COPY ClientManager.Domain/*.csproj ClientManager.Domain/
COPY ClientManager.Domain.Tests/*.csproj ClientManager.Domain.Tests/

COPY *.sln ClientManager.sln

RUN dotnet restore

COPY . .

RUN dotnet build -c Release --no-restore

RUN dotnet publish ClientManager.Domain.Api/ClientManager.Domain.Api.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "ClientManager.Domain.Api.dll"]