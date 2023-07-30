using Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreWeb.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-R6K64T9\SQLEXPRESS;Database=CoreWebDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
            );
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        Name = "Admin",
                        Surname = "Admin",
                        UserName = "Admin",
                        Password = "123456",
                        Email = "admin@coreweb.net",
                        Phone = "1234567890",
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
