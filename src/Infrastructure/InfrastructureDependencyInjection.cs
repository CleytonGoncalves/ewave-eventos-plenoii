using System;
using Application.Core.Emails;
using Infrastructure.Data;
using Infrastructure.Emails;
using Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services,
            IConfiguration cfg)
        {
            services.AddPersistence(cfg);
            services.AddMessaging();
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }

        public static void UseInfra(IServiceProvider serviceProvider)
        {
            serviceProvider.InitializePersistence();
        }
    }
}
