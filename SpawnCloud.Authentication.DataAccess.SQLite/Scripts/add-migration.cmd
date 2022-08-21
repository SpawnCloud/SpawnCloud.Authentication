SET MigrationName=%~1

IF "%MigrationName%" == "" (
  EXIT
)

cd ../../

SET SPAWNCLOUD_AUTH_DatabaseProvider=SQLITE

dotnet ef migrations add --project SpawnCloud.Authentication.DataAccess.SQLite\SpawnCloud.Authentication.DataAccess.SQLite.csproj --startup-project SpawnCloud.Authentication\SpawnCloud.Authentication.csproj --context SpawnCloud.Authentication.DataAccess.SQLite.SqliteAuthDbContext --configuration Debug "%MigrationName%" --output-dir Migrations
