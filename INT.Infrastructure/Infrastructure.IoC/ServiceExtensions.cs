using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace INT.Infrastructure.Infrastructure.IoC
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:INTDatabase"));


            var allowedOrigin = configuration.GetValue("AllowedOrigins", "*").Split(";");

            services.AddCors(options =>
            {
                options.AddPolicy("AllowedHosts",
                    policy =>
                    {
                        policy.WithOrigins(allowedOrigin)
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                    });
            });
        }


        //public static void MigrateDatabase(this IServiceProvider serviceProvider)
        //{
        //    var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

        //    using (var dbContext = new ApplicationDbContext(dbContextOptions))
        //    {
        //        dbContext.Database.Migrate();
        //    }
        //}
    }
}
