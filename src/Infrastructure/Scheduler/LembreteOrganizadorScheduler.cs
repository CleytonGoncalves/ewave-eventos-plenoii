using System;
using Application.Core.Scheduler;
using Domain.Palestras.ValueObjects;
using Hangfire;

namespace Infrastructure.Scheduler
{
    public class LembreteOrganizadorScheduler : ILembreteOrganizadorScheduler
    {
        private readonly IBackgroundJobClient _job;

        public LembreteOrganizadorScheduler(IBackgroundJobClient job)
        {
            _job = job;
        }

        public void Schedule(PalestraId palestraId, DateTimeOffset dataExecucao)
        {
            _job.Schedule<ISendEmailLembreteOrganizador>(
                x => x.SendEmailLembrete(palestraId.Value),
                dataExecucao
            );
        }
    }
}
