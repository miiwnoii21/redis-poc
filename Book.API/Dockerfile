FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /Book.API

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /Book.API
COPY --from=build-env /Book.API/out .

# Expose the port your application will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "Book.API.dll"]
