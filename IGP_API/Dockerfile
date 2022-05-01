FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["../IGP_API/IGP_API.csproj", "IGP_API/"]
RUN dotnet restore "../IGP_API/IGP_API.csproj"
COPY . .
WORKDIR "/src/IGP_API"
RUN dotnet build "IGP_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IGP_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IGP_API.dll"]
