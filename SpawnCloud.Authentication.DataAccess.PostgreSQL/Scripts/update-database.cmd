cd ../../

SET AUTH_DatabaseProvider=POSTGRESQL

dotnet ef database update --project SpawnCloud.Services.Authentication.DataAccess.PostgreSQL\SpawnCloud.Services.Authentication.DataAccess.PostgreSQL.csproj --startup-project SpawnCloud.Services.Authentication\SpawnCloud.Services.Authentication.csproj