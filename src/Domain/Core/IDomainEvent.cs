using System;

namespace Domain.Core
{
    public interface IDomainEvent
    {
        DateTimeOffset OccurredOn { get; }
    }
}
