FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet tool install --global dotnet-ef
# RUN dotnet restore "YourApp.csproj"
RUN dotnet build "YourApp.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "YourApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourApp.dll"]