using System;
using System.Threading.Tasks;

namespace Infrastructure.Scheduler
{
    public interface ISendEmailLembreteOrganizador
    {
        Task SendEmailLembrete(Guid palestraId);
    }
}
