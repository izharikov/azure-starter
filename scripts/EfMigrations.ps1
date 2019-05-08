param(
    [Parameter(Mandatory = $false)]
    $Name,
    [Parameter(Mandatory = $true)]
    [ValidateSet('Add', 'UpdateDb', 'RevertAll', 'RemoveAll', 'Script')]
    $Option
)

$efProject = "..\src\database\Azure.Starter.Database\Azure.Starter.Database.csproj"
$efStartupProject = "..\src\web\Azure.Starter.Web\Azure.Starter.Web.csproj"

switch ($Option)
{
    'RevertAll'{
        dotnet ef database update 0 --project $efProject --startup-project $efStartupProject
    }

    'RemoveAll'{
        dotnet ef migrations remove --project $efProject --startup-project $efStartupProject
    }

    'Add' {
        dotnet ef migrations add $Name --project $efProject --startup-project $efStartupProject
    }

    'UpdateDb'{
        dotnet ef database update  --project $efProject --startup-project $efStartupProject
    }

    'Script' {
        dotnet ef migrations script -o script.sql.user -i -p $efProject -s $efStartupProject --no-build
    }
}