FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 6060
EXPOSE 6061

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Horizon.Api/Horizon.Api.csproj", "src/Horizon.Api/"]
COPY ["src/Horizon.Application/Horizon.Application.csproj", "src/Horizon.Application/"]
COPY ["src/Horizon.Infrastructure/Horizon.Infrastructure.csproj", "src/Horizon.Infrastructure/"]
COPY ["src/Horizon.Domain/Horizon.Domain.csproj", "src/Horizon.Domain/"]
RUN dotnet restore "src/Horizon.Api/Horizon.Api.csproj"
COPY . .
WORKDIR "/src/src/Horizon.Api"
RUN dotnet build "Horizon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Horizon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Horizon.Api.dll"]
