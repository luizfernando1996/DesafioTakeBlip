#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ProjectTakeApi/ProjectTakeApi.csproj", "ProjectTakeApi/"]
RUN dotnet restore "ProjectTakeApi/ProjectTakeApi.csproj"
COPY . .
WORKDIR "/src/ProjectTakeApi"
RUN dotnet build "ProjectTakeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectTakeApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Padrao de container ASP.NET
# ENTRYPOINT ["dotnet", "ProjectTakeApi.dll"]
# Opcao utilizada pelo Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ProjectTakeApi.dll