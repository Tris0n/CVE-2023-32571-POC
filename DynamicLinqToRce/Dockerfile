# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the csproj file into the container and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the source code into the container
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Create a minimal ASP.NET Core runtime image for execution
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the published files from the build image
COPY --from=build /app/out .

# Set the startup command for the application
CMD ["dotnet", "DynamicLinqToRce.dll"]
