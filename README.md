# Blog website application (CoreWeb) with ASP.NET Core MVC

## CoreWeb Api Addresses
[ASP.NET Core API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) is an open-source, cross-platform web API framework developed by Microsoft. It is built on top of the .NET Core runtime and can run on various platforms such as Windows, macOS, and Linux.
<br>
You can import the MSSQL database: `CoreWebDB.bacpac`
<br>

## Used Packages

### Client-Side Library -> Manage Client-Side Libraries
![](/pictures/clientside.png)
- Some packages can be installed from the "[Manage Client-Side Libraries](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-7.0)" with the help of the `Solution Explorer > ProjectName Right Click > Add > Client-Side Library > Library + Install`.
```
    >    bootstrap@5.3.1
```
```
    >    jquery@3.7.0
```
![](/pictures/addclientside.PNG)

---- 

### NuGet Gallery
![](/pictures/nuget.png)
- Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [Microsoft.EntityFrameworkCore 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore -Version 7.0.9
```
- [Microsoft.EntityFrameworkCore.SqlServer 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.9
```
- [Microsoft.EntityFrameworkCore.Design 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 7.0.9
```
- [Microsoft.EntityFrameworkCore.Tools 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.9
```
- [Microsoft.EntityFrameworkCore.Proxies 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Proxies -Version 7.0.9
```
- [Microsoft.EntityFrameworkCore.Relational 7.0.9](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Relational/7.0.9)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Relational -Version 7.0.9
```
- [Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.15](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/6.0.15)
```
    PM>  NuGet\Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.15
```
![](/pictures/nugetconsole.PNG)

The `Add-Migration` command is used to create or apply changes to database tables using the Code First approach supported by Entity Framework Core. This command detects the changes made in your model and saves them as a migration. Migrations allow you to evolve your application's database over time.
Write the following command to the `Tools > NuGet Package Manager > Package Manager Console`.
```
    PM>  add-migration InitialCreate
``` 
We write our other command to update the database.
```
    PM>  update-database
```

---- 

If an error like the following occurs:
```
    ClientConnectionId:c0c7f465-92a0-4810-80cd-0e7250f876ef
    Error Number:-2146893019,State:0,Class:20
    A connection was successfully established with the server, but then an error occurred during the login process. 
    (provider: SSL Provider, error: 0 - Sertifika zinciri güvenilmeyen bir yetkili tarafından verildi.)
```
Try adding `TrustServerCertificate=True;` to your connection string in `CoreWeb\Data\DatabaseContext.cs`. [[source]](https://learn.microsoft.com/en-us/answers/questions/663116/a-connection-was-successfully-established-with-the)
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-R6K64T9\SQLEXPRESS;Database=CoreWebDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
            );
        }
```
... 