using System;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras
{
    public interface IColisaoLocalPalestraChecker
    {
        bool IsLocalDisponivelNoHorario(Local local, DateTimeOffset dataInicial, DateTimeOffset dataFinal);
    }
}
