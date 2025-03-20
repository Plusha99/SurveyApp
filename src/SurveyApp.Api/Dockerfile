# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# В зависимости от операционной системы хост-компьютеров, которые будут выполнять сборку контейнеров или запускать их, может потребоваться изменить образ, указанный в инструкции FROM.
# Дополнительные сведения см. на странице https://aka.ms/containercompat

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:9.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SurveyApp.Api/SurveyApp.Api.csproj", "src/SurveyApp.Api/"]
COPY ["src/SurveyApp.Application/SurveyApp.Application.csproj", "src/SurveyApp.Application/"]
COPY ["src/SurveyApp.Domain/SurveyApp.Domain.csproj", "src/SurveyApp.Domain/"]
COPY ["src/SurveyApp.Infrastructure/SurveyApp.Infrastructure.csproj", "src/SurveyApp.Infrastructure/"]
RUN dotnet restore "./src/SurveyApp.Api/SurveyApp.Api.csproj"
COPY . .
WORKDIR "/src/src/SurveyApp.Api"
RUN dotnet build "./SurveyApp.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SurveyApp.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyApp.Api.dll"]