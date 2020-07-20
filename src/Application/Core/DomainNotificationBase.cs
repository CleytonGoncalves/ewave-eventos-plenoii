using Domain.Core;

namespace Application.Core
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T>
        where T : IDomainEvent
    {
        public T DomainEvent { get; }

        public DomainNotificationBase(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
