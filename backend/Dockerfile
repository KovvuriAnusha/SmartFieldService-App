FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./

# ✅ Restore using project file (fix)
RUN dotnet restore SmartFieldService.Api/SmartFieldService.Api.csproj

# ✅ Publish API
RUN dotnet publish SmartFieldService.Api/SmartFieldService.Api.csproj -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "SmartFieldService.Api.dll"]