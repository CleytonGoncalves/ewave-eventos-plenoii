using Domain.Core;
using Domain.Funcionarios;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras.Participacoes
{
    public class ParticipacaoAdicionadaEvent : DomainEventBase
    {
        public PalestraId PalestraId { get; }
        public FuncionarioId FuncionarioId { get; }

        public StatusParticipacao Status { get; }

        public ParticipacaoAdicionadaEvent(PalestraId palestraId, FuncionarioId funcionarioId,
            StatusParticipacao status)
        {
            PalestraId = palestraId;
            FuncionarioId = funcionarioId;
            Status = status;
        }
    }
}
