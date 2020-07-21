using System;
using Application.Core;
using Application.Core.Data;
using EntityFramework.Exceptions.SqlServer;
using Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    internal static class DataDependencyInjection
    {
        internal static IServiceCollection AddPersistence(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContextPool<PalestraContext>(options =>
            {
                options
                    .UseNpgsql(connectionString)
                    .UseExceptionProcessor()
                    // Adiciona o conversor de IDs tipados no EF
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                    .EnableDetailedErrors() // Deve ser desabilitado em produção
                    .EnableSensitiveDataLogging(); // Deve ser desabilitado em produção
            });

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(c => c.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }

        /// <summary> Aplica automaticamente as migrations </summary>
        internal static void InitializePersistence(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PalestraContext>();
                context.Database.Migrate();
            }
        }
    }
}
