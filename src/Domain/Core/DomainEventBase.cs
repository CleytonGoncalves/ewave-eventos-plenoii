using System;

namespace Domain.Core
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public DateTimeOffset OccurredOn { get; }

        protected DomainEventBase()
        {
            OccurredOn = DateTimeOffset.Now;
        }

        public override string ToString() => $"{GetType().Name}: {nameof(OccurredOn)}: {OccurredOn}";
    }
}
