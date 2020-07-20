using System.Threading;
using System.Threading.Tasks;
using Domain.Funcionarios;
using Domain.Palestras;
using Domain.Palestras.Participacoes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Palestras.ParticiparPalestra
{
    public class ParticipacaoAdicionadaNotificationHandler : INotificationHandler<ParticipacaoAdicionadaNotification>
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        private readonly ILogger<ParticipacaoAdicionadaNotificationHandler> _logger;

        public ParticipacaoAdicionadaNotificationHandler(IPalestraRepository palestraRepository,
            IFuncionarioRepository funcionarioRepository, ILogger<ParticipacaoAdicionadaNotificationHandler> logger)
        {
            _palestraRepository = palestraRepository;
            _funcionarioRepository = funcionarioRepository;
            _logger = logger;
        }

        public async Task Handle(ParticipacaoAdicionadaNotification notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            var funcionario = await _funcionarioRepository.GetBy(domainEvent.FuncionarioId, cancellationToken);
            var palestra = await _palestraRepository.GetBy(domainEvent.PalestraId, cancellationToken);

            _logger.LogCritical($"## ENVIAR EMAIL SOBRE A INSCRIÇÃO PARA O FUNCIONARIO ## {palestra.Titulo} - {funcionario.Email}");

            if (domainEvent.Status == StatusParticipacao.PendenteConfirmacaoSuperior)
                _logger.LogCritical($"## ENVIAR EMAIL PARA O CHEFE CONFIRMAR ## {palestra.Titulo} - {funcionario.SuperiorEmail}");
        }
    }
}
