﻿using System;
using Application.Core;
using Application.Core.Data;
using EntityFramework.Exceptions.SqlServer;
using Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    internal static class DataDependencyInjection
    {
        private const string CONNECTION_STRING_NAME = "DefaultConnection";
        private const string HEROKU_DB_ENV = "DATABASE_URL";

        internal static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration cfg)
        {
            var connectionString = GetConnectionString(cfg);

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

        private static string GetConnectionString(IConfiguration cfg)
        {
            string connStr;
            if (TryGetHerokuConnectionString(out string? herokuConnStr))
                connStr = herokuConnStr!;
            else
                connStr = cfg.GetConnectionString(CONNECTION_STRING_NAME);

            return connStr!;
        }

        /// <summary> Detecta se está rodando no heroku e retorna sua connection string </summary>
        /// <returns>True, se tiver rodando no Heroku. Caso contrário, False</returns>
        private static bool TryGetHerokuConnectionString(out string? connStr)
        {
            string? connUrl = Environment.GetEnvironmentVariable(HEROKU_DB_ENV);

            if (string.IsNullOrEmpty(connUrl))
            {
                connStr = null;
                return false;
            }

            // Parse connection URL to connection string for Npgsql
            connUrl = connUrl.Replace("postgres://", string.Empty, StringComparison.OrdinalIgnoreCase);
            var pgUserPass = connUrl.Split("@")[0];
            var pgHostPortDb = connUrl.Split("@")[1];
            var pgHostPort = pgHostPortDb.Split("/")[0];
            var pgDb = pgHostPortDb.Split("/")[1];
            var pgUser = pgUserPass.Split(":")[0];
            var pgPass = pgUserPass.Split(":")[1];
            var pgHost = pgHostPort.Split(":")[0];
            var pgPort = pgHostPort.Split(":")[1];

            connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}";
            return true;
        }
    }
}
