using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
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
