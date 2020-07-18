using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Configurations
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
        {
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.IncludeXmlComments(GenerateXmlCommentsFilePath()));

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

        private static string GenerateXmlCommentsFilePath()
        {
            string basePath = AppContext.BaseDirectory;
            string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";

            return Path.Combine(basePath, fileName);
        }

        internal class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _versionProvider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider versionProvider)
            {
                _versionProvider = versionProvider;
            }

            public void Configure(SwaggerGenOptions options)
            {
                // Add a swagger document for each discovered API version
                foreach (var description in _versionProvider.ApiVersionDescriptions)
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }

            private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo
                {
                    Title = "Palestras API",
                    Description = "Desafio Técnico Ewave",
                    Version = description.ApiVersion.ToString(),
                    Contact = new OpenApiContact
                    {
                        Name = "Cleyton Gonçalves",
                        Email = "cleyton@cleytongoncalves.com",
                        Url = new Uri("https://cleytongoncalves.com")
                    },
                };

                if (description.IsDeprecated)
                    info.Description += " This API version has been deprecated.";

                return info;
            }
        }
    }
}
