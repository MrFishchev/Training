#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

ENV ASPNETCORE_URLS http://+:8001
EXPOSE 8001

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DockerTraining.GuidGeneratorService/DockerTraining.GuidGeneratorService.csproj", "DockerTraining.GuidGeneratorService/"]
RUN dotnet restore "DockerTraining.GuidGeneratorService/DockerTraining.GuidGeneratorService.csproj"
COPY . .
WORKDIR "/src/DockerTraining.GuidGeneratorService"
RUN dotnet build "DockerTraining.GuidGeneratorService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerTraining.GuidGeneratorService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTraining.GuidGeneratorService.dll"]