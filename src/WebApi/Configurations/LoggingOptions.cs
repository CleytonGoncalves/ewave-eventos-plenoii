using System;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Events;

namespace WebApi.Configurations
{
    public static class LoggingOptions
    {
        private const string MESSAGE_TEMPLATE =
            "HTTP {RequestMethod} to '{Path}' responded with {StatusCode} in {Elapsed:0} ms";

        public static void Configure(RequestLoggingOptions? options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.MessageTemplate = MESSAGE_TEMPLATE;
            options.GetLevel = RequestLogLevel;
            options.EnrichDiagnosticContext = EnrichRequest;
        }

        private static LogEventLevel RequestLogLevel(HttpContext httpCtx, double elapsedMs, Exception? ex)
        {
            if (ex != null || httpCtx.Response.StatusCode >= 500)
                return LogEventLevel.Error;

            if (httpCtx.Request.Path.Value == "/service-worker.js")
                return LogEventLevel.Verbose;

            return httpCtx.Request.Method != "OPTIONS" ? LogEventLevel.Information : LogEventLevel.Debug;
        }

        private static void EnrichRequest(IDiagnosticContext diagnosticCtx, HttpContext httpCtx)
        {
            diagnosticCtx.Set("IpAddress", httpCtx.Connection?.RemoteIpAddress?.ToString() ?? "- Unknown -");
            diagnosticCtx.Set("User", httpCtx.User?.Identity.Name ?? "- Unauthenticated -");

            if (httpCtx.Request.Path.HasValue)
                diagnosticCtx.Set("Path", httpCtx.Request.Path.Value);

            if (httpCtx.Request.QueryString.HasValue)
                diagnosticCtx.Set("QueryString", httpCtx.Request.QueryString);

            var endpoint = httpCtx.GetEndpoint();
            if (endpoint != null)
                diagnosticCtx.Set("EndpointName", endpoint.DisplayName);
        }
    }
}
