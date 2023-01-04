#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SeeLive.Api/SeeLive.Api.csproj", "src/SeeLive.Api/"]
COPY ["src/SeeLive.Infrastructure/SeeLive.Infrastructure.csproj", "src/SeeLive.Infrastructure/"]
COPY ["src/SeeLive.Domain/SeeLive.Domain.csproj", "src/SeeLive.Domain/"]
RUN dotnet restore "src/SeeLive.Api/SeeLive.Api.csproj"
COPY . .
WORKDIR "/src/src/SeeLive.Api"
RUN dotnet build "SeeLive.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeeLive.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeeLive.Api.dll"]