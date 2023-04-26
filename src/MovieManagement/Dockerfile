FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MovieManagement/MovieManagement.csproj", "src/MovieManagement/"]
RUN dotnet restore "src/MovieManagement/MovieManagement.csproj"
COPY . .
WORKDIR "/src/src/MovieManagement"
RUN dotnet build "MovieManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieManagement.dll"]
