using System.Reflection;
using Application.Core.Pipelines;
using Application.Core.Validations;
using Domain.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core.Modules
{
    public static class ApplicationDependencyInjection
    {
        private static readonly Assembly DOMAIN_ASSEMBLY = typeof(EntityBase).Assembly;
        private static readonly Assembly APPLICATION_ASSEMBLY = typeof(ApplicationDependencyInjection).Assembly;

        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(APPLICATION_ASSEMBLY);
            services.AddMediatR(DOMAIN_ASSEMBLY, APPLICATION_ASSEMBLY);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(c => c.Where(type => type.Namespace!.EndsWith("Services")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}
