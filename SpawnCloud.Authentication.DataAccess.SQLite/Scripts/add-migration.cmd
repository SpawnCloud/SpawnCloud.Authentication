SET MigrationName=%~1

IF "%MigrationName%" == "" (
  EXIT
)

cd ../../

SET AUTH_DatabaseProvider=SQLITE

dotnet ef migrations add --project SpawnCloud.Services.Authentication.DataAccess.SQLite\SpawnCloud.Services.Authentication.DataAccess.SQLite.csproj --startup-project SpawnCloud.Services.Authentication\SpawnCloud.Services.Authentication.csproj --context SpawnCloud.Services.Authentication.DataAccess.SQLite.SqliteAuthDbContext --configuration Debug "%MigrationName%" --output-dir Migrations
