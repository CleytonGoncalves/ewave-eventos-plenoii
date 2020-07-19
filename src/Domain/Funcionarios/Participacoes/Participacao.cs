using Domain.Core;
using Domain.Palestras.ValueObjects;

namespace Domain.Funcionarios.Participacoes
{
    public class Participacao : EntityBase
    {
        public ParticipacaoId Id { get; }

        public PalestraId PalestraId { get; private set; }
        public StatusParticipacao Status { get; private set; }

        public Participacao(PalestraId palestraId, StatusParticipacao status)
        {
            Id = new ParticipacaoId();
            PalestraId = palestraId;
            Status = status;
        }
    }
}
