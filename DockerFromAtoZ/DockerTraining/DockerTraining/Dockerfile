#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

ENV ASPNETCORE_URLS http://+:8000
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DockerTraining/DockerTraining.csproj", "DockerTraining/"]
RUN dotnet restore "DockerTraining/DockerTraining.csproj"
COPY . .
WORKDIR "/src/DockerTraining"
RUN dotnet build "DockerTraining.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerTraining.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTraining.dll"]