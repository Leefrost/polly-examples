FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/HostService/HostService.csproj", "HostService/"]
RUN dotnet restore "src/HostService/HostService.csproj"
COPY . .
WORKDIR "/src/HostService"
RUN dotnet build "HostService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HostService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostService.dll"]
