#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["DataContracts/DataContracts.csproj", "DataContracts/"]
COPY ["Managers/Managers.csproj", "Managers/"]
COPY ["Engines/Engines.csproj", "Engines/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet API.dll#ENTRYPOINT ["dotnet", "API.dll"]