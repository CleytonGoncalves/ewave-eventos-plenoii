using Domain.Core;
using Domain.Palestras.ValueObjects;
using Domain.SharedKernel;

namespace Domain.Palestras.Events
{
    public class PalestranteDefinidoEvent : DomainEventBase
    {
        public PalestraId PalestraId { get; set; }

        public string PalestranteNome { get; set; }
        public Email PalestranteEmail { get; set; }

        public PalestranteDefinidoEvent(PalestraId palestraId, string palestranteNome, Email palestranteEmail)
        {
            PalestraId = palestraId;
            PalestranteNome = palestranteNome;
            PalestranteEmail = palestranteEmail;
        }
    }
}
