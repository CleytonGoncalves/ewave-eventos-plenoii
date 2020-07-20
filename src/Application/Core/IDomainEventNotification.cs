using Domain.Core;
using MediatR;

namespace Application.Core
{
    public interface IDomainEventNotification<out TEventType> : INotification
        where TEventType : IDomainEvent
    {
        TEventType DomainEvent { get; }
    }
}
