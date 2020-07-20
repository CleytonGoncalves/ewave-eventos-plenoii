using Application.Core;
using Domain.Palestras.Events;

namespace Application.Palestras.ParticiparPalestra
{
    public class ParticipacaoAdicionadaNotification : DomainNotificationBase<ParticipacaoAdicionadaEvent>
    {
        public ParticipacaoAdicionadaNotification(ParticipacaoAdicionadaEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
