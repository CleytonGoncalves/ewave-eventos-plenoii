using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Messaging
{
    internal static class MessagingDependencyInjection
    {
        internal static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return services;
        }
    }
}
