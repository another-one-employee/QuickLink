FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuickLink.Web/QuickLink.Web.csproj", "QuickLink.Web/"]
COPY ["QuickLink.Infrastructure/QuickLink.Infrastructure.csproj", "QuickLink.Infrastructure/"]
COPY ["QuickLink.Application/QuickLink.Application.csproj", "QuickLink.Application/"]
RUN dotnet restore "./QuickLink.Web/QuickLink.Web.csproj"
COPY . .
WORKDIR "/src/QuickLink.Web"
RUN dotnet build "./QuickLink.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuickLink.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuickLink.Web.dll"]