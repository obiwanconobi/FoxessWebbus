FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FoxessWebbus.Web/FoxessWebbus.Web.csproj", "FoxessWebbus.Web/"]
RUN dotnet restore "FoxessWebbus.Web/FoxessWebbus.Web.csproj"
COPY . .
WORKDIR "/src/FoxessWebbus.Web"
RUN dotnet build "FoxessWebbus.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoxessWebbus.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoxessWebbus.Web.dll"]