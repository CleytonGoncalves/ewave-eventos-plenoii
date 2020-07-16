#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["*.sln", "."]
COPY ["WebApi/*.csproj", "WebApi/"]
COPY ["UnitTests/*.csproj", "UnitTests/"]
RUN dotnet restore
COPY . .

# Build & Test
WORKDIR "/src/WebApi"
RUN dotnet build -c Release -o /app/build
WORKDIR "/src/UnitTests"
RUN dotnet test

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]