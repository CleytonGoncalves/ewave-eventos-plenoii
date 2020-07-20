using System.Collections.Generic;
using System.Linq;
using Domain.Core;
using Domain.Funcionarios;
using Domain.Palestras.Participacoes;

namespace Domain.Palestras.Rules
{
    public class ParticipacaoDuplicadaRule : IBusinessRule
    {
        private readonly IReadOnlyCollection<Participacao> _participacoes;
        private readonly FuncionarioId _funcionarioId;

        public ParticipacaoDuplicadaRule(IReadOnlyCollection<Participacao> participacoes, FuncionarioId funcionarioId)
        {
            _participacoes = participacoes;
            _funcionarioId = funcionarioId;
        }

        public bool IsBroken() => _participacoes.Any(x => x.FuncionarioId == _funcionarioId);

        public string Message => Messages.ParticipacaoAlreadyExists;
    }
}
