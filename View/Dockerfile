﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["View/View.csproj", "View/"]
COPY ["App/App.csproj", "App/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DAL/DAL.csproj", "DAL/"]
RUN dotnet restore "View/View.csproj"
COPY . .
WORKDIR "/src/View"
RUN dotnet build "View.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "View.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "View.dll"]
