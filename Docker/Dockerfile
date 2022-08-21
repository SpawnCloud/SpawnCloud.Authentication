FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS publish
WORKDIR /src
COPY [".", "./"]

RUN dotnet publish "SpawnCloud.Services.Authentication.Server/SpawnCloud.Services.Authentication.Server.csproj" -c Release -o /app/publish \
    --runtime alpine-x64 \
    --self-contained true \
    /warnaserror

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS final

RUN adduser --disabled-password \
    --home /app \
    --gecos '' dotnetuser && chown -R dotnetuser /app 

RUN apk upgrade musl

USER dotnetuser
WORKDIR /app
EXPOSE 5000
COPY --from=publish /app/publish .
ENTRYPOINT ["./SpawnCloud.Services.Authentication.Server", "--urls", "http://localhost:5000"]
