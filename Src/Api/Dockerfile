# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Api/Api.csproj", "Api/"]

# Copy the entire project and build
COPY . .
WORKDIR "/src/Api"

run dotnet restore

RUN dotnet build "Api.csproj" --no-restore -c Release -o /app/build

# Install EF Core CLI
RUN dotnet tool install --global dotnet-ef --version 8.0.4 && \
    /root/.dotnet/tools/dotnet-ef migrations bundle

# Publish the application
FROM build AS publish
RUN dotnet publish "Api.csproj" --no-restore -c Release -o /app/publish

# Final image for execution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /src .
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools

ENV PATH="${PATH}:/root/.dotnet/tools"

# Set environment variable for dotnet watch
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV URLS="http://*:8080"

WORKDIR "/app/Api"
ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "--no-launch-profile", "--configuration", "Debug"]