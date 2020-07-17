using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Configurations
{
    public static class ApiVersioningExtensions
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // v'major[.minor][-status]
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
