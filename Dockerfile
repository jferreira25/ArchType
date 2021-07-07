FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY nuget.config ./
COPY Api/Projeto.Base.Admin.csproj Api/
COPY CrossCutting.Configuration/Projeto.Base.CrossCutting.Configuration.csproj CrossCutting.Configuration/
COPY Domain/Projeto.Base.Domain.csproj Domain/
COPY Infrastructure.Data/Projeto.Base.Infrastructure.Data.csproj Infrastructure.Data/
COPY Infrastructure.Publisher/Projeto.Base.Infrastructure.Publisher.csproj Infrastructure.Publisher/
COPY Infrastructure.Subscriber/Projeto.Base.Infrastructure.Subscriber.csproj Infrastructure.Subscriber/
COPY Infrastructure.Service/Projeto.Base.Infrastructure.Service.csproj Infrastructure.Service/
COPY Tests.Integration/Projeto.Base.Tests.Integration.csproj Tests.Integration/
COPY Tests.Shared/Projeto.Base.Tests.Shared.csproj Tests.Shared/
COPY Tests.Unity/Projeto.Base.Tests.Unity.csproj Tests.Unity/
RUN dotnet restore 

# Copy everything else and build
COPY . .
WORKDIR "/src/Api"

RUN mv appsettings.Docker.json appsettings.json
RUN dotnet publish "Projeto.Base.Admin.csproj" -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS base
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Projeto.Base.Admin.dll"]