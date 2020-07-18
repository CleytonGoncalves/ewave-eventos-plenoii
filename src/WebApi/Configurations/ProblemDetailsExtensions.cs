using System;
using System.Data;
using System.Net.Http;
using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.Configurations
{
    public static class ProblemDetailsExtensions
    {
        public static IServiceCollection AddConfiguredProblemDetails(this IServiceCollection services)
        {
            services.ConfigureOptions<ProblemDetailsCustomOptionsSetup>();
            return services.AddProblemDetails();
        }

        internal class ProblemDetailsCustomOptionsSetup : IConfigureOptions<ProblemDetailsOptions>
        {
            public void Configure(ProblemDetailsOptions options)
            {
                options.IncludeExceptionDetails = (context, exception) => true; // Deve ser desabilitado em produção

                options.ShouldLogUnhandledException = (httpCtx, ex, details) => false;
                MapExceptions(options);

                options.Rethrow<Exception>((httpCtx, exception) => httpCtx.Response.StatusCode >= 500);
            }

            /// <summary> Determina o Http Status Code que exceptions específicas devem gerar </summary>
            private static void MapExceptions(ProblemDetailsOptions options)
            {
                /* Exceções genéricas */

                options.MapToStatusCode<DBConcurrencyException>(Status409Conflict);
                options.MapToStatusCode<HttpRequestException>(Status503ServiceUnavailable);

                // Mapeia as exceções não mapeadas acima - Deve ficar por último
                options.MapToStatusCode<Exception>(Status500InternalServerError);
            }
        }
    }
}
