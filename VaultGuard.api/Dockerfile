#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VaultGuard.api/VaultGuard.api.csproj", "VaultGuard.api/"]
RUN dotnet restore "VaultGuard.api/VaultGuard.api.csproj"
COPY . .
WORKDIR "/src/VaultGuard.api"
RUN dotnet build "VaultGuard.api.csproj" -c Release -o /app/build

COPY ["VaultGuard.api/Keys/private_key.pem", "/app/private_key.pem"]

FROM build AS publish
RUN dotnet publish "VaultGuard.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VaultGuard.api.dll"]


