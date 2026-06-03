FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MarketAPI.csproj", "."]
RUN dotnet restore "./MarketAPI.csproj"
COPY . .
RUN dotnet build "MarketAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketAPI.dll"]