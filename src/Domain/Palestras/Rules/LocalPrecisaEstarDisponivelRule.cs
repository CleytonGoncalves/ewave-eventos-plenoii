using System;
using Domain.Core;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras.Rules
{
    public class LocalPrecisaEstarDisponivelRule : IBusinessRule
    {
        private readonly IColisaoLocalPalestraChecker _colisaoLocalChecker;

        private readonly Local _local;
        private readonly DateTimeOffset _dataInicial;
        private readonly DateTimeOffset _dataFinal;

        public LocalPrecisaEstarDisponivelRule(IColisaoLocalPalestraChecker colisaoLocalChecker, Local local,
            DateTimeOffset dataInicial, DateTimeOffset dataFinal)
        {
            _colisaoLocalChecker = colisaoLocalChecker;
            _local = local;
            _dataInicial = dataInicial;
            _dataFinal = dataFinal;
        }

        public bool IsBroken() => ! _colisaoLocalChecker.IsLocalDisponivelNoHorario(_local, _dataInicial, _dataFinal);

        public string Message => Messages.LocalNotAvailable;
    }
}
