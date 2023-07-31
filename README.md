# Submit and share site application (CoreWeb) with ASP.NET Core MVC

## CoreWeb Api Addresses
[ASP.NET Core API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) is an open-source, cross-platform web API framework developed by Microsoft. It is built on top of the .NET Core runtime and can run on various platforms such as Windows, macOS, and Linux.
<br />
If we want to start the project with [Microsoft Visual Studio](https://visualstudio.microsoft.com/), we start the project by right-clicking on the "[CoreWeb\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/coreweb/blob/main/CoreWeb/Views/Home/Index.cshtml)" file while the project is open and selecting "View in Browser ([Selected Browser](https://www.google.com.tr/))".

If we want, we can also use `\Index.cshtml` of other "[\Views](https://github.com/AtakanTurgut/coreweb/tree/main/CoreWeb/Areas/Admin/Views)" files to see how other pages look.

However, it's best to start the project with "[CoreWeb\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/coreweb/blob/main/CoreWeb/Views/Home/Index.cshtml)" to run it properly.

Ready-made [bootstrap themes](https://getbootstrap.com/docs/5.3/examples/) were processed and made suitable for the project.
<br />
You can import the MSSQL database: `CoreWebDB.bacpac`
<br />
Admin can perform general operations through the panel. <br />
<ul>
  <li>The website is accessible.</li>
  <li>Admin can see what's happening on the dashboard from the control panel.</li>
  <li>Admin can perform operations related to Users and list all Users. Can add, delete, edit Users.</li>
  <li>Admin can perform operations related to Categories and list all Categories. Can add, delete, edit Categories.</li>
  <li>Admin can perform operations related to Contact Information and list all Contact Information. Can add, delete, edit Contact Information.</li>
  <li>Admin can perform operations related to News and list all News. Can add, delete, edit News.</li>
  <li>Admin can perform operations related to Posts and list all Posts. Can add, delete, edit Posts.</li>
  <li>Admin can perform operations related to Sliders and list all Sliders. Can add, delete, edit Sliders.</li>
</ul>  
<br />
Use this user name and password for the admin page.

                Email    : admin@coreweb.net
                Password : 123456

The project runs on "[localhost:?/](https://localhost:44329/)".

---- 
### Projects    =>    Reference Manager
Data Access Layer (DAL) => Entities
<br />
Business Layer (BL)     => DAL + Entities
<br />
CoreWeb (Presentation)  => BL + Entities

---- 
## [Program.cs](https://github.com/AtakanTurgut/coreweb/blob/main/CoreWeb/Program.cs) highlights for .Net 6.0 
```c#
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer());  // Admin panel context
builder.Services.AddDbContext<DataBaseContext>(); // DAL context

app.UseAuthentication();    //  Login processes  ->  Oturum açma işlemleri
app.UseAuthorization();     //  Authorization control procedures  ->  Yetki kontrolü işlemleri
// An authorization check cannot be performed without logging in. ->  Oturum açmadan yetkilendirme kontrolü yapılamaz.
// First Authentication  >>  Then Authorization
```
---- 
## Used Packages

### Client-Side Library -> Manage Client-Side Libraries
- Some packages can be installed from the "[Manage Client-Side Libraries](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-7.0)" with the help of the `Solution Explorer > ProjectName Right Click > Add > Client-Side Library > Library + Install`.
```
    >    bootstrap@5.3.1
```
```
    >    jquery@3.7.0
```
![](/pictures/clientside.png)
![](/pictures/addclientside.PNG)

---- 
### NuGet Gallery
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
![](/pictures/nuget.png)
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
Try adding `TrustServerCertificate=True;` to your connection string in "[CoreWeb\Data\DatabaseContext.cs](https://github.com/AtakanTurgut/coreweb/blob/main/CoreWeb/Data/DatabaseContext.cs)". [[source]](https://learn.microsoft.com/en-us/answers/questions/663116/a-connection-was-successfully-established-with-the)
```c#
public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-R6K64T9\SQLEXPRESS;Database=CoreWebDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
        );
    }
}
```
-----
## CoreWeb Project [Images](https://github.com/AtakanTurgut/coreweb/tree/main/pictures)

### 1. Home Page:  https://localhost:44329/Home/Index
![](/pictures/HomePage1.PNG) 
![](/pictures/HomePage2.PNG)
![](/pictures/HomePage3.PNG)
![](/pictures/HomePage4.PNG)

### 2. News Details Page:  https://localhost:44329/News/Detail/1
![](/pictures/NewsDetailsPage.PNG)

### 3. Post Details Page:  https://localhost:44329/Post/Detail/2
![](/pictures/PostDetailsPage.PNG)

### 4. Contact Page:  https://localhost:44329/Home/Contact
![](/pictures/ContactPage.PNG)

### 5. Admin Login Page:  https://localhost:44329/Admin/Login
![](/pictures/AdminLoginPage.PNG)

### 7. Admin Page:  https://localhost:44329/Admin
![](/pictures/AdminPage.PNG)

### 6. Users Conroller Page:  https://localhost:44329/Admin/Users
![](/pictures/UsersPage.PNG)

### 7. Categories Conroller Page:  https://localhost:44329/Admin/Categories
![](/pictures/CategoriesPage.PNG)

### 8. Category Create Page:  https://localhost:44329/Admin/Categories/Create
![](/pictures/CategoryCreatePage.PNG)

### 9. Category Edit Page:  https://localhost:44329/Admin/Categories/Edit/1
![](/pictures/CategoryEditPage.PNG)

### 10. Contacts Conroller Page:  https://localhost:44329/Admin/Contacts
![](/pictures/ContactsPage.PNG)

### 11. News Conroller Page:  https://localhost:44329/Admin/News
![](/pictures/NewsPage1.PNG)
![](/pictures/NewsPage2.PNG)

### 12. Posts Conroller Page:  https://localhost:44329/Admin/Posts
![](/pictures/PostsPage.PNG)

### 13. Sliders Conroller Page:  https://localhost:44329/Admin/Sliders
![](/pictures/SlidersPage.PNG)

---
"[FileZilla](https://filezilla-project.org)" can be used to make the site live.
