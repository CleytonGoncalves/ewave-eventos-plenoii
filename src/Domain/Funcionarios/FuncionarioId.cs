using System;
using Domain.Core;

namespace Domain.Funcionarios
{
    public class FuncionarioId : TypedIdBase
    {
        public FuncionarioId(Guid value) : base(value)
        {
        }

        public FuncionarioId()
        {
        }
    }
}
