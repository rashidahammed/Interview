using INT.Application.Application.Interfaces;
using INT.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace INT.Infrastructure.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        private static readonly int _sessionTimeout = 20;

        public static void RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserContext, CurrentUserContext>();

           
            //services.AddScoped<IJwtTokenService, JwtTokenService>();
            //services.AddScoped<IDocumentService, DocumentService>();
            //services.AddScoped<IDocumentSigneeService, DocumentSigneeService>();

        }
    }
}
