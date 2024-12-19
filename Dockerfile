FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["project-court-backend.csproj", "./"]
RUN dotnet restore "project-court-backend.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "project-court-backend.csproj" -c --no-launch-profile -o /app/build

FROM build AS publish
ARG PROFILE=Development
RUN dotnet publish "project-court-backend.csproj" -c --no-launch-profile -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project-court-backend.dll"]