cd ../../

SET SPAWNCLOUD_AUTH_DatabaseProvider=SQLITE
SET SPAWNCLOUD_AUTH_ConnectionStrings__AuthDbConnection=Data Source=development.db

dotnet ef database update --project SpawnCloud.Authentication.DataAccess.SQLite\SpawnCloud.Authentication.DataAccess.SQLite.csproj --startup-project SpawnCloud.Authentication\SpawnCloud.Authentication.csproj