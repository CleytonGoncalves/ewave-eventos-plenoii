using Domain.SharedKernel;

namespace Application.Core.Emails
{
    public class EmailMessage
    {
        public Email To { get; }
        public string Content { get; }

        public EmailMessage(Email to, string content)
        {
            To = to;
            Content = content;
        }
    }
}
