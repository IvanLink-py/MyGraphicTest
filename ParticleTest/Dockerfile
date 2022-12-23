FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ParticleTest/ParticleTest.csproj", "ParticleTest/"]
RUN dotnet restore "ParticleTest/ParticleTest.csproj"
COPY . .
WORKDIR "/src/ParticleTest"
RUN dotnet build "ParticleTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParticleTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParticleTest.dll"]
