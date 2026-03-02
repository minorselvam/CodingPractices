# Use the official ASP.NET Core runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Expose port 80
EXPOSE 80

# Force Kestrel to listen on port 80
ENV ASPNETCORE_URLS=http://+:80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final stage: build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotNetCoreWebApi.dll"]
