using Application.Core.Modules;
using Hangfire;
using Hellang.Middleware.ProblemDetails;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebApi.Configurations;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddConfiguredJson();

            services.AddConfiguredProblemDetails();
            services.AddConfiguredApiVersioning();
            services.AddConfiguredSwagger();

            services.AddInfrastructureDependencyInjection(Configuration);
            services.AddApplicationDependencyInjection();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionProvider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                // Exibe o IP real do request se houver um reverse-proxy
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();

            app.UseHangfireDashboard(); //Will be available under http://localhost:5000/hangfire"

            app.UseSerilogRequestLogging(LoggingOptions.Configure);

            app.UseProblemDetails();

            app.UseRouting();

            app.UseVersionedSwagger(apiVersionProvider);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            InfrastructureDependencyInjection.InitializeDatabase(app.ApplicationServices);

            app.UseHangfireServer();
        }
    }
}
