FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StocksApi/StocksApi.csproj", "StocksApi/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
RUN dotnet restore "StocksApi/StocksApi.csproj"
COPY . .
WORKDIR "/src/StocksApi"
RUN dotnet build "StocksApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StocksApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StocksApi.dll"]