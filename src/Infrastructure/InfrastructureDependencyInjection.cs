using System;
using Application.Core.Emails;
using Infrastructure.Data;
using Infrastructure.Emails;
using Infrastructure.Messaging;
using Infrastructure.Scheduler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        private const string CONNECTION_STRING_NAME = "DefaultConnection";
        private const string HEROKU_DB_ENV = "DATABASE_URL";

        public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services,
            IConfiguration cfg)
        {
            string connectionString = GetConnectionString(cfg);
            services.AddPersistence(connectionString);
            services.AddMessaging();
            services.AddScheduler(connectionString);

            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            serviceProvider.InitializePersistence();
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
