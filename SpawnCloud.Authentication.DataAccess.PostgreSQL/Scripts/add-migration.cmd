SET MigrationName=%~1

IF "%MigrationName%" == "" (
  EXIT
)

cd ../../

SET AUTH_DatabaseProvider=POSTGRESQL
 
dotnet ef migrations add --project SpawnCloud.Services.Authentication.DataAccess.PostgreSQL\SpawnCloud.Services.Authentication.DataAccess.PostgreSQL.csproj --startup-project SpawnCloud.Services.Authentication\SpawnCloud.Services.Authentication.csproj --context SpawnCloud.Services.Authentication.DataAccess.PostgreSQL.PostgreSqlAuthDbContext --configuration Debug "%MigrationName%" --output-dir Migrations
