using INT.Application.Application.Interfaces;
using INT.Application.Application.Mapper;
using INT.Application.Application.Services;
using INT.Domain.Domain.Core.Repositories;
using INT.Domain.Domain.Interfaces;
using INT.Infrastructure.Contexts;
using INT.Infrastructure.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace INT.Infrastructure.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMappingProfile));
            services.AddScoped<ICurrentUserContext, CurrentUserContext>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IRoleRepositories, RoleRepositories>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IValidationServices, ValidationServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserRepositories, UserRepositories>();
            services.AddScoped<IUserRoleRepositories, UserRoleRepositories>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUserLoginServices, UserLoginServices>();
        }
    }
}
