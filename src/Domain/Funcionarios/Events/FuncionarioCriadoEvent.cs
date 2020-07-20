using Domain.Core;

namespace Domain.Funcionarios.Events
{
    public class FuncionarioCriadoEvent : DomainEventBase
    {
        public FuncionarioId FuncionarioId { get; set; }

        public FuncionarioCriadoEvent(FuncionarioId funcionarioId)
        {
            FuncionarioId = funcionarioId;
        }
    }
}
