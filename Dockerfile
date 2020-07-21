# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY *.sln ./
COPY . ./
RUN dotnet restore

# Testing
FROM build AS testing
RUN dotnet test tests/UnitTests/UnitTests.csproj --no-restore

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /src/publish -r linux-x64

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS final
WORKDIR /app
ENV DOCKERIZE_VERSION v0.6.1
RUN apt-get update && apt-get install -y wget
RUN wget --quiet https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && rm dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz
COPY --from=publish /src/publish .
ENTRYPOINT dotnet WebApi.dll
