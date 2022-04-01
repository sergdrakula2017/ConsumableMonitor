#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["ConsumableMonitor.Server/ConsumableMonitor.Server.csproj", "ConsumableMonitor.Server/"]
COPY ["ConsumableMonitor.Data/ConsumableMonitor.Data.csproj", "ConsumableMonitor.Data/"]
COPY ["ConsumableMonitor.Models/ConsumableMonitor.Models.csproj", "ConsumableMonitor.Models/"]
RUN dotnet restore "ConsumableMonitor.Server/ConsumableMonitor.Server.csproj"
COPY . .
WORKDIR "/src/ConsumableMonitor.Server"
RUN dotnet build "ConsumableMonitor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsumableMonitor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumableMonitor.Server.dll"]
