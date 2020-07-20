using System;

namespace Application.Funcionarios
{
    public sealed class FuncionarioDto
    {
        public Guid Id { get; }

        public FuncionarioDto(Guid id)
        {
            Id = id;
        }
    }
}
