cd ../../

SET SPAWNCLOUD_AUTH_DatabaseProvider=POSTGRESQL

dotnet ef database update --project SpawnCloud.Authentication.DataAccess.PostgreSQL\SpawnCloud.Authentication.DataAccess.PostgreSQL.csproj --startup-project SpawnCloud.Authentication\SpawnCloud.Authentication.csproj