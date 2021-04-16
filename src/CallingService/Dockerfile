FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "*.csproj" "CallingService/"
RUN dotnet restore "/src/CallingService/CallingService.csproj"
WORKDIR "/src/CallingService"
COPY . .
RUN dotnet build "CallingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CallingService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CallingService.dll"]
