using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace WebApi
{
    public static class Program
    {
        private static readonly string ENVIRONMENT =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;

        public static void Main(string[] args)
        {
            Log.Logger = BuildLogger(BuildConfiguration());

            #pragma warning disable CA1031 // Usa 'Exception' não-específico p/ logar qualquer que seja a causa da falha
            try
            {
                Log.Information("Servidor Iniciado");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Servidor terminou inesperadamente");
            }
            finally
            {
                Log.Information("Servidor Finalizado");
                Log.CloseAndFlush(); // Importante p/ garantir que todos os logs sejam realizados antes de finalizar
            }
            #pragma warning restore CS1031
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureAppConfiguration(ConfigureCustomAppConfiguration);

        private static IConfiguration BuildConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            ConfigureCustomAppConfiguration(configBuilder);

            return configBuilder.Build();
        }

        private static void ConfigureCustomAppConfiguration(IConfigurationBuilder configBuilder)
        {
            configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{ENVIRONMENT}.json", true, true);

            configBuilder.AddEnvironmentVariables();
        }

        private static ILogger BuildLogger(IConfiguration configuration)
        {
            var loggerBuilder = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                    .WithIgnoreStackTraceAndTargetSiteExceptionFilter()
                    .WithDefaultDestructurers()
                );

            return loggerBuilder.CreateLogger();
        }
    }
}
