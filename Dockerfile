# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY *.sln ./
COPY . ./
RUN dotnet restore

# Testing
FROM build AS testing
RUN dotnet test tests/UnitTests/UnitTests.csproj

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS final
WORKDIR /app
COPY --from=publish /src/publish .
ENTRYPOINT dotnet WebApi.dll
