#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 444

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Gbso.App.Api/Gbso.App.Api.csproj", "Gbso.App.Api/"]
RUN dotnet restore "Gbso.App.Api/Gbso.App.Api.csproj"
COPY . .
WORKDIR "/src/Gbso.App.Api"
RUN dotnet build "Gbso.App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gbso.App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gbso.App.Api.dll"]