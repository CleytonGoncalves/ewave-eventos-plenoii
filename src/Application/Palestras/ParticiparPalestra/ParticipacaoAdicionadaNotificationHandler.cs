using System.Threading;
using System.Threading.Tasks;
using Application.Core.Emails;
using Domain.Funcionarios;
using Domain.Palestras;
using Domain.Palestras.Participacoes;
using MediatR;

namespace Application.Palestras.ParticiparPalestra
{
    public class ParticipacaoAdicionadaNotificationHandler : INotificationHandler<ParticipacaoAdicionadaNotification>
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEmailSender _emailSender;

        public ParticipacaoAdicionadaNotificationHandler(IPalestraRepository palestraRepository,
            IFuncionarioRepository funcionarioRepository, IEmailSender emailSender)
        {
            _palestraRepository = palestraRepository;
            _funcionarioRepository = funcionarioRepository;
            _emailSender = emailSender;
        }

        public async Task Handle(ParticipacaoAdicionadaNotification notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            var funcionario = await _funcionarioRepository.GetBy(domainEvent.FuncionarioId, cancellationToken);
            var palestra = await _palestraRepository.GetBy(domainEvent.PalestraId, cancellationToken);

            await _emailSender.SendEmailAsync(new EmailMessage(funcionario.Email, $"Palestra: {palestra.Titulo} - Data: {palestra.DataInicial:g}"));

            if (domainEvent.Status == StatusParticipacao.PendenteConfirmacaoSuperior)
                await _emailSender.SendEmailAsync(new EmailMessage(funcionario.Email, $"Funcionário '{funcionario.SuperiorEmail}' deseja participar da Palestra: {palestra.Titulo} na Data: {palestra.DataInicial:g}"));
        }
    }
}
