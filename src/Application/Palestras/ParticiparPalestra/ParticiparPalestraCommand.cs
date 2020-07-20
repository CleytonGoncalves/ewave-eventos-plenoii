using Domain.Funcionarios;
using Domain.Palestras.ValueObjects;
using MediatR;

namespace Application.Palestras.ParticiparPalestra
{
    public sealed class ParticiparPalestraCommand : IRequest
    {
        public PalestraId PalestraId { get; private set; }
        public FuncionarioId FuncionarioId { get; private set; }

        public ParticiparPalestraCommand(PalestraId palestraId, FuncionarioId funcionarioId)
        {
            PalestraId = palestraId;
            FuncionarioId = funcionarioId;
        }
    }
}
