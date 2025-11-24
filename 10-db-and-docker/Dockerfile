FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AutoMarketApp.Entities/AutoMarketApp.Entities.csproj", "AutoMarketApp.Entities/"]
COPY ["AutoMarketApp.Infrastructure/AutoMarketApp.Infrastructure.csproj", "AutoMarketApp.Infrastructure/"]
COPY ["AutoMarketApp.UseCases/AutoMarketApp.UseCases.csproj", "AutoMarketApp.UseCases/"]
COPY ["AutoMarketApp.Presentation/AutoMarketApp.Presentation.csproj", "AutoMarketApp.Presentation/"]
COPY ["AutoMarketApp.Host/AutoMarketApp.Host.csproj", "AutoMarketApp.Host/"]

RUN dotnet restore "AutoMarketApp.Host/AutoMarketApp.Host.csproj"

COPY . .

WORKDIR "/src/AutoMarketApp.Host"

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS publish
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "AutoMarketApp.Host.dll"]