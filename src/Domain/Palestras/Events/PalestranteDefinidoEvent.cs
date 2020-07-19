using Domain.Core;

namespace Domain.Palestras.Events
{
    public class PalestranteDefinidoEvent : DomainEventBase
    {
        public PalestraId PalestraId { get; set; }
        public string Palestrante { get; set; }

        public PalestranteDefinidoEvent(PalestraId palestraId, string palestrante)
        {
            PalestraId = palestraId;
            Palestrante = palestrante;
        }
    }
}
