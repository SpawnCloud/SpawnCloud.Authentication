SET MigrationName=%~1

IF "%MigrationName%" == "" (
  EXIT
)

cd ../../

SET SPAWNCLOUD_AUTH_DatabaseProvider=POSTGRESQL
 
dotnet ef migrations add --project SpawnCloud.Authentication.DataAccess.PostgreSQL\SpawnCloud.Authentication.DataAccess.PostgreSQL.csproj --startup-project SpawnCloud.Authentication\SpawnCloud.Authentication.csproj --context SpawnCloud.Authentication.DataAccess.PostgreSQL.PostgreSqlAuthDbContext --configuration Debug "%MigrationName%" --output-dir Migrations
