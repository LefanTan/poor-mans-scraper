FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/playwright/dotnet:v1.23.0
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "WebScrapeApi.dll", "--urls", "http://0.0.0.0:5185"]