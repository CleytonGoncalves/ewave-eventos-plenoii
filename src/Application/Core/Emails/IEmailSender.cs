using System.Threading.Tasks;

namespace Application.Core.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message);
    }
}
