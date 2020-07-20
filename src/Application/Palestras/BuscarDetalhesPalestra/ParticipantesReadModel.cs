using System;
using Domain.Palestras.Participacoes;

namespace Application.Palestras.BuscarDetalhesPalestra
{
    public class ParticipantesReadModel
    {
        public Guid FuncionarioId { get; set; }
        public StatusParticipacao Status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? SuperiorEmail { get; set; }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private ParticipantesReadModel() // Constructor pro Dapper
        {
        }
        #pragma warning restore 8618
    }
}
