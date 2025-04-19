using INT.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace INT.Infrastructure.Infrastructure.Data.Context
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new List<Role> {
                new Role { Id = 1, Name = "Admin",NameHi="व्यवस्थापक",Description="Full controll",DescriptionHi="पूर्ण नियंत्रण",CreatedBy=1,CreatedOn=DateTime.Now,IsDeleted=false},
            });

            modelBuilder.Entity<User>().HasData(new List<User> {
                new User { Id = 1, Name = "Super Admin",NameHi="व्यवस्थापक",Email="test@gmail.com",Password="",CreatedBy=1,IsActive=true,CreatedOn=DateTime.Now,IsDeleted=false},
            });

            modelBuilder.Entity<UserRole>().HasData(new List<UserRole> {
                new UserRole { Id = 1, UserId=1,RoleId=1,CreatedBy=1,CreatedOn=DateTime.Now,IsDeleted=false},
            });

        }
    }
}
