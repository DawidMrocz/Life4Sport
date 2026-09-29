#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get -y update
RUN apt-get -y install curl

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Identity.Api/Identity.Api.csproj", "Identity.Api/"]
COPY ["Identity.Core/Identity.Core.csproj", "Identity.Core/"]
COPY ["Identity.Data/Identity.Data.csproj", "Identity.Data/"]
COPY ["Shared/Framework.Shared.csproj", "Shared/"]
COPY ["Framework.Identity/Framework.Identity.csproj", "Framework.Identity/"]


RUN dotnet restore "Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]





#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#COPY ["Identity.Api/Identity.Api.csproj", "Identity.Api/"]
#RUN dotnet restore "Identity.Api/Identity.Api.csproj"
#COPY . .
#WORKDIR "/src/Identity.Api"
#RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Identity.Api.dll"]