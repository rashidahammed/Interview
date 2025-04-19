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
            //JwtToken(services, configuration);
            LoadAppConstant(configuration);
        }

        private static void LoadAppConstant(IConfiguration configuration)
        {
            // aspose settings
            //APPConstants.AsposeLicensePath = ConfigurationBinder.GetValue<string>(configuration, "AsposeLicensePath", @"C:\Intalio.Core.Aspose.Total.Product.Family.lic");
        }

        private static void JwtToken(IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.Events = new JwtBearerEvents
              {
                  OnMessageReceived = context =>
                  {
                      var path = context.HttpContext.Request.Path;
                      if (path.StartsWithSegments("/api/auth/login") ||
                          path.StartsWithSegments("/swagger") ||
                          path.StartsWithSegments("/api/auth/register"))
                      {
                          context.NoResult();
                      }

                      return Task.CompletedTask;
                  }
              };

              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = false,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = configuration["Jwt:Issuer"],
                  ValidAudience = configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
              };
          });

          services.AddAuthorization();
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
