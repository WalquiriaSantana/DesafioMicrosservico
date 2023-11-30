#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Livraria.Worker/Livraria.Worker.csproj", "src/Livraria.Worker/"]
RUN dotnet restore "src/Livraria.Worker/Livraria.Worker.csproj"
COPY . .
WORKDIR "/src/src/Livraria.Worker"
RUN dotnet build "Livraria.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Livraria.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Livraria.Worker.dll"]