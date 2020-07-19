using Domain.Core;
using Domain.Funcionarios;

namespace Domain.Palestras.Participacoes
{
    public class Participacao : EntityBase
    {
        public ParticipacaoId Id { get; }

        public FuncionarioId FuncionarioId { get; private set; }
        public StatusParticipacao Status { get; private set; }

        public Participacao(FuncionarioId funcionarioId, StatusParticipacao status)
        {
            Id = new ParticipacaoId();
            FuncionarioId = funcionarioId;
            Status = status;
        }
    }
}
