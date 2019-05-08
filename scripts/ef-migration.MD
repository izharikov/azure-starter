## Create Migration:
```
dotnet ef migrations add InitialMigrations 
    --project ..\src\database\Azure.Starter.Database\Azure.Starter.Database.csproj 
    --startup-project ..\src\web\Azure.Starter.Web\Azure.Starter.Web.csproj
```
## Clean all migrations:
```

```
## Update Database:
```
dotnet ef database update 
    --project ..\src\database\Azure.Starter.Database\Azure.Starter.Database.csproj 
    --startup-project ..\src\web\Azure.Starter.Web\Azure.Starter.Web.csproj
```

## Generate Script:
```
dotnet ef migrations script 
    --project ..\src\database\Azure.Starter.Database\Azure.Starter.Database.csproj 
    --startup-project ..\src\web\Azure.Starter.Web\Azure.Starter.Web.csproj
```