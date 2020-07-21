using Application.Core.Scheduler;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Scheduler
{
    internal static class SchedulerDependencyInjection
    {
        internal static IServiceCollection AddScheduler(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(x => x.UsePostgreSqlStorage(connectionString));

            services.AddTransient<IBackgroundJobClient, BackgroundJobClient>(x =>
                new BackgroundJobClient(new PostgreSqlStorage(connectionString)));

            services.AddTransient<ILembreteOrganizadorScheduler, LembreteOrganizadorScheduler>();
            services.AddTransient<ISendEmailLembreteOrganizador, SendEmailLembreteOrganizador>();

            return services;
        }
    }
}
