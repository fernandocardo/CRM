#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CRM.API/CRM.API.csproj", "CRM.API/"]
RUN dotnet restore "CRM.API/CRM.API.csproj"
COPY . .
WORKDIR "/src/CRM.API"
RUN dotnet build "CRM.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRM.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRM.API.dll"]