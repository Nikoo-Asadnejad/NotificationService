FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SmsService/SmsService.csproj", "SmsService/"]
RUN dotnet restore "SmsService/SmsService.csproj"
COPY . .
WORKDIR "/src/SmsService"
RUN dotnet build "SmsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmsService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmsService.dll"]
