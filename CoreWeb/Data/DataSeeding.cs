using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWeb.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DatabaseContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Users.Count() == 0)
                {
                    User user = new User() 
                    {
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        Name = "Admin",
                        Surname = "Admin",
                        UserName = "Admin",
                        Password = "123456",  
                        Email = "admin@coreweb.net"
                    }; 

                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
    }
}
