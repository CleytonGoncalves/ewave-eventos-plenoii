using Domain.Core;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras.Events
{
    public class PalestraCriadaEvent : DomainEventBase
    {
        public PalestraId PalestraId { get; set; }

        public PalestraCriadaEvent(PalestraId palestraId)
        {
            PalestraId = palestraId;
        }
    }
}
