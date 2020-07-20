using System.Collections.Generic;
using Domain.Core;
using Domain.Palestras.Participacoes;

namespace Domain.Palestras.Rules
{
    public class LimiteDeParticipacoesRule : IBusinessRule
    {
        private readonly IReadOnlyCollection<Participacao> _participacoes;

        public LimiteDeParticipacoesRule(IReadOnlyCollection<Participacao> participacoes)
        {
            _participacoes = participacoes;
        }

        public bool IsBroken() => _participacoes.Count > 20;

        public string Message => Messages.PalestraFullError;
    }
}
