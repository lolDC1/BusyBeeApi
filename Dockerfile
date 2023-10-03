FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BusyBee.Api/BusyBee.Api.csproj", "BusyBee.Api/"]
COPY ["BusyBee.Persistence.Design/BusyBee.Persistence.Design.csproj", "BusyBee.Persistence.Design/"]
COPY ["BusyBee.Persistence/BusyBee.Persistence.csproj", "BusyBee.Persistence/"]
COPY ["BusyBee.Core/BusyBee.Core.csproj", "BusyBee.Core/"]
RUN dotnet restore "BusyBee.Api/BusyBee.Api.csproj"
COPY . .
WORKDIR "/src/BusyBee.Api"
RUN dotnet build "BusyBee.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusyBee.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusyBee.Api.dll"]