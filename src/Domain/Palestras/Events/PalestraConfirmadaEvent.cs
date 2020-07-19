using Domain.Core;

namespace Domain.Palestras.Events
{
    public class PalestraConfirmadaEvent : DomainEventBase
    {
        public PalestraId PalestraId { get; set; }

        public PalestraConfirmadaEvent(PalestraId palestraId)
        {
            PalestraId = palestraId;
        }
    }
}
