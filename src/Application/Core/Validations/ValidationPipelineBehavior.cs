using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Validations
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger,
            IEnumerable<IValidator<TRequest>> validators)
        {
            _logger = logger;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogDebug("Command validation started");

            var validations = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request, cancellationToken)));
            var errors = validations.SelectMany(v => v.Errors).Where(e => e != null).ToList();

            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();

                errorBuilder.AppendLine(Messages.InvalidCommandError);
                foreach (var error in errors)
                    errorBuilder.AppendLine(error.ErrorMessage);

                _logger.LogDebug($"Command validation failed: {errorBuilder}");
                throw new InvalidCommandException(errorBuilder.ToString());
            }

            _logger.LogDebug("Comand validation succeeded");
            return await next();
        }
    }
}
