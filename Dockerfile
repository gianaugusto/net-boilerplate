# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NetBoilerplate/NetBoilerplate.csproj", "NetBoilerplate/"]
RUN dotnet restore "NetBoilerplate/NetBoilerplate.csproj"
COPY . .
WORKDIR "/src/NetBoilerplate"
RUN dotnet build "NetBoilerplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetBoilerplate.csproj" -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetBoilerplate.Api.dll"]
