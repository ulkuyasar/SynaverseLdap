#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SynaverseLdap/SynaverseLdap.csproj", "SynaverseLdap/"]
RUN dotnet restore "SynaverseLdap/SynaverseLdap.csproj"
COPY . .
WORKDIR "/src/SynaverseLdap"
RUN dotnet build "SynaverseLdap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SynaverseLdap.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SynaverseLdap.dll"]