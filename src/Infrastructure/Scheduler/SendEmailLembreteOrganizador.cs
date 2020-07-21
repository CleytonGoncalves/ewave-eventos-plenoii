using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Emails;
using Domain.Palestras.ValueObjects;
using Infrastructure.Data;

namespace Infrastructure.Scheduler
{
    public class SendEmailLembreteOrganizador : ISendEmailLembreteOrganizador
    {
        private readonly PalestraContext _context;
        private readonly IEmailSender _emailSender;

        public SendEmailLembreteOrganizador(PalestraContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task SendEmailLembrete(Guid palestraId)
        {
            var palestra = _context.Palestras.First(x => x.Id == new PalestraId(palestraId));

            var emailOrganizador = palestra.OrganizadorEmail;
            var conteudoMsg =
                $"Falta 1 semana para a palestra '{palestra.Titulo}'! A sala {palestra.Local} já foi reservada? Palestrante confirmado?";

            var email = new EmailMessage(emailOrganizador, conteudoMsg);

            await _emailSender.SendEmailAsync(email);
        }
    }
}
