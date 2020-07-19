using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Domain.Core;

namespace UnitTests.Core
{
    public static class AggregateExtensions
    {
        public static AggregateAssertions Should(this EntityBase instance) => new AggregateAssertions(instance);

        public static List<IDomainEvent> GetAllDomainEvents(this EntityBase aggregate)
        {
            var domainEvents = new List<IDomainEvent>();

            if (aggregate.DomainEvents.Any())
                domainEvents.AddRange(aggregate.DomainEvents);

            ExecuteActionOnSubAggregateEvents(aggregate, (subAggregates) =>
                domainEvents.AddRange(GetAllDomainEvents(subAggregates)));

            return domainEvents;
        }

        public static void ClearAllDomainEvents(this EntityBase aggregate)
        {
            aggregate.ClearDomainEvents();
            ExecuteActionOnSubAggregateEvents(aggregate, ClearAllDomainEvents);
        }

        private static void ExecuteActionOnSubAggregateEvents(EntityBase aggregate, Action<EntityBase> action)
        {
            var fields = aggregate.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Concat(aggregate.GetType().BaseType!.GetFields(BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.Public))
                .ToArray();

            foreach (var field in fields)
            {
                bool isEntity = field.FieldType.IsAssignableFrom(typeof(EntityBase));

                if (isEntity)
                {
                    var entity = field.GetValue(aggregate) as EntityBase;
                    action(entity);
                }

                if (field.FieldType == typeof(string) || ! typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                    continue;

                if (field.GetValue(aggregate) is IEnumerable enumerable)
                {
                    foreach (var en in enumerable)
                    {
                        if (en is EntityBase entityItem)
                            action(entityItem);
                    }
                }
            }
        }
    }
}
