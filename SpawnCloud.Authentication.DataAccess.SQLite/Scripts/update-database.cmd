cd ../../

SET AUTH_DatabaseProvider=SQLITE
SET AUTH_ConnectionStrings__AuthDbConnection=Data Source=development.db

dotnet ef database update --project SpawnCloud.Services.Authentication.DataAccess.SQLite\SpawnCloud.Services.Authentication.DataAccess.SQLite.csproj --startup-project SpawnCloud.Services.Authentication\SpawnCloud.Services.Authentication.csproj