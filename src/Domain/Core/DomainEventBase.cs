using System;

namespace Domain.Core
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTimeOffset OccurredOn { get; }

        public DomainEventBase()
        {
            OccurredOn = DateTimeOffset.Now;
        }
    }
}
