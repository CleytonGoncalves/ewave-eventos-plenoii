using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Configurations
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.IncludeXmlComments(XmlCommentsFilePath));

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app,
            IApiVersionDescriptionProvider? versionProvider)
        {
            if (versionProvider == null)
                throw new ArgumentNullException(nameof(versionProvider));

            app.UseSwagger();

            /* Ordered by major version so swagger displays the newest version first */
            var apiVersionDescriptions = versionProvider.ApiVersionDescriptions
                .OrderByDescending(x => x.ApiVersion.MajorVersion);

            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }

                options.RoutePrefix = string.Empty; // Puts swagger UI at the root path
            });

            return app;
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                string basePath = AppContext.BaseDirectory;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
