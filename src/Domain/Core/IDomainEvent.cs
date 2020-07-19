using System;
using MediatR;

namespace Domain.Core
{
    public interface IDomainEvent : INotification
    {
        DateTimeOffset OccurredOn { get; }
    }
}
