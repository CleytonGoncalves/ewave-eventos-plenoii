using System.Threading.Tasks;
using Application.Core.Emails;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<IEmailSender> _logger;

        public EmailSender(ILogger<IEmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(EmailMessage message)
        {
            // Chamar serviço de email aqui
            _logger.LogInformation("Email enviado para {To}. Conteúdo: {Content}", message.To, message.Content);

            return Task.CompletedTask;
        }
    }
}
