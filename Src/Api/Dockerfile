# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "Core/Core.csproj"
RUN dotnet restore "Infrastructure/Infrastructure.csproj"
RUN dotnet restore "Application/Application.csproj"
RUN dotnet restore "Api/Api.csproj"

# Copy the entire project and build
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

# Install EF Core CLI
RUN dotnet tool install --global dotnet-ef --version 8.0.4 && \
    /root/.dotnet/tools/dotnet-ef migrations bundle

# Publish the application
FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

# Final image for execution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools

ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "Api.dll"]