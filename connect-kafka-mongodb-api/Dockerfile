FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8090

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["connect-kafka-mongodb-api/connect-kafka-mongodb-api.csproj", "connect-kafka-mongodb-api/"]
RUN dotnet restore "connect-kafka-mongodb-api/connect-kafka-mongodb-api.csproj"
COPY . .
WORKDIR "/src/connect-kafka-mongodb-api"
RUN dotnet build "connect-kafka-mongodb-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "connect-kafka-mongodb-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "connect-kafka-mongodb-api.dll"]
