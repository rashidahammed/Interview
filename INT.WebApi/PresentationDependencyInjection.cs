using INT.WebApi.Mapper;

namespace INT.WebApi
{
    public static class PresentationDependencyInjection
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PresentationMappingProfile));
        }
    }
}
