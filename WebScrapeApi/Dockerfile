FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

RUN dotnet dev-certs https

ENTRYPOINT [ "dotnet", "watch", "run"]
