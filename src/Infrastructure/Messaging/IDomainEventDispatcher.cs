using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core;

namespace Infrastructure.Messaging
{
    public interface IDomainEventDispatcher
    {
        Task<IList<IDomainEvent>> DispatchEvents();
        Task DispatchNotifications(ICollection<IDomainEvent> domainEvents);
    }
}
