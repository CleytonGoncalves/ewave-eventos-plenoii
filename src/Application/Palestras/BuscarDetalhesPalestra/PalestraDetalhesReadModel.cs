using System;
using System.Collections.Generic;
using Domain.Palestras.ValueObjects;

namespace Application.Palestras.BuscarDetalhesPalestra
{
    public class PalestraDetalhesReadModel
    {
        public Guid PalestraId { get; set; }
        public string Tema { get; set; }
        public string Titulo { get; set; }
        public DateTimeOffset DataInicial { get; set; }
        public DateTimeOffset DataFinal { get; set; }
        public StatusPalestra Status { get; set; }
        public Local Local { get; set; }

        public string OrganizadorEmail { get; set; }

        public string? PalestranteNome { get; set; }
        public string? PalestranteEmail { get; set; }

        public IEnumerable<ParticipantesReadModel> Participantes { get; set; } = new List<ParticipantesReadModel>();

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private PalestraDetalhesReadModel() // Constructor pro Dapper
        {
        }
        #pragma warning restore 8618
    }
}
