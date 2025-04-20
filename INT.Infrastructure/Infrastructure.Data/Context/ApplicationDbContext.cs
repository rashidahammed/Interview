using INT.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace INT.Infrastructure.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            var abc = hasher.HashPassword(null, "Aa@123456789");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new List<Role> {
                new Role { Id = 1, Name = "Admin",NameHi="व्यवस्थापक",Description="Full controll",DescriptionHi="पूर्ण नियंत्रण",CreatedBy=1,CreatedOn=DateTime.Now,IsDeleted=false},
            });

            modelBuilder.Entity<User>().HasData(new List<User> {
                new User { Id = 1,UserName="Admin", Name = "Super Admin",NameHi="व्यवस्थापक",Email="test@gmail.com",Password=hasher.HashPassword(null, "Aa@123456789"),CreatedBy=1,CreatedOn=DateTime.Now,IsDeleted=false},
            });


            modelBuilder.Entity<UserRole>().HasData(new List<UserRole> {
                new UserRole { Id = 1, RoleId=1,UserId=1,CreatedBy=1,CreatedOn=DateTime.Now,IsDeleted=false},
            });
        }
    }
}
