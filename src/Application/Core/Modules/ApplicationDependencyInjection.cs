using System.Reflection;
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

            return services;
        }
    }
}
