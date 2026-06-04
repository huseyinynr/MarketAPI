FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MarketAPI.csproj", "MarketAPI/"]
RUN dotnet restore "MarketAPI/MarketAPI.csproj"
COPY . ./MarketAPI/
WORKDIR "/src/MarketAPI"
RUN dotnet build "MarketAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/MarketAPI/market.db ./market.db
ENTRYPOINT ["dotnet", "MarketAPI.dll"]