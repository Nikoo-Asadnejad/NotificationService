FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/PushService/PushService.csproj", "Services/PushService/"]
RUN dotnet restore "Services/PushService/PushService.csproj"
COPY . .
WORKDIR "/src/Services/PushService"
RUN dotnet build "PushService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PushService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PushService.dll"]
