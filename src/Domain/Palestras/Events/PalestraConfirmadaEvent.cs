using Domain.Core;
using Domain.Palestras.ValueObjects;

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
