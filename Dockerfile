FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY *.sln ./
COPY PcShop/*.csproj ./PcShop/
RUN dotnet restore PcShop/PcShop.csproj

COPY PcShop/. ./PcShop/
WORKDIR /src/PcShop
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PcShop.dll"]
