# Use ASP.NET Core runtime for the base stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Update the path for the .csproj file (since it's at the root, not in an API/ folder)
COPY ["API.csproj", "./"]

# Restore dependencies
RUN dotnet restore "./API.csproj"

# Copy all the source code
COPY . .

# Set the working directory to the correct path
WORKDIR "/src"

# Build the project
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: Build the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables
ENV Rabbitmq__cs="amqps://qwvdekvk:ntdjljAIjeuMpY80W9AU9NrJBL3FMuvh@gerbil.rmq.cloudamqp.com/qwvdekvk"
ENV Redis__cs="trusted-humpback-26161.upstash.io:6379,password=AWYxAAIjcDFlZGI4MzU2YjAxMDQ0ZGVlYWYwMDAzNjQ3NGEyNzFkMXAxMA,ssl=True,abortConnect=False"
ENV MongoDBSettings__ConnectionString="mongodb+srv://Owais:owais@cluster0.wde1dec.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"
ENV MongoDBSettings__DatabaseName="TaskDB"

# Start the application
ENTRYPOINT ["dotnet", "API.dll"]
