using System;
using Domain.Palestras.ValueObjects;

namespace Application.Core.Scheduler
{
    public interface ILembreteOrganizadorScheduler
    {
        void Schedule(PalestraId palestraId, DateTimeOffset dataExecucao);
    }
}
