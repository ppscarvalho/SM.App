using Microsoft.Extensions.DependencyInjection;

namespace SM.Integration.Application.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()), typeof(object));
        }
    }
}
