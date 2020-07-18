using System;
using Domain.Core;

namespace Domain.Funcionarios.Participacoes
{
    public class ParticipacaoId : TypedIdBase
    {
        public ParticipacaoId(Guid value) : base(value)
        {
        }

        public ParticipacaoId()
        {
        }
    }
}
