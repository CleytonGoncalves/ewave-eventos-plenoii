using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Palestras.ParticiparPalestra;
using Domain.Core;
using Domain.Palestras.Events;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Messaging
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly PalestraContext _context;

        public DomainEventDispatcher(IMediator mediator, PalestraContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IList<IDomainEvent>> DispatchEvents()
        {
            var domainEntities = GetEntitiesFromContext();
            var domainEvents = domainEntities.SelectMany(x => x.DomainEvents).ToList();

            foreach (var entity in domainEntities)
                entity.ClearDomainEvents();

            var tasks = domainEvents.Select(domainEvent => _mediator.Publish(domainEvent));
            await Task.WhenAll(tasks);

            return domainEvents;
        }

        public async Task DispatchNotifications(ICollection<IDomainEvent> domainEvents)
        {
            var notifications = new List<IDomainEventNotification<IDomainEvent>>();

            foreach (var domainEvent in domainEvents)
            {
                if (! EVENT_NOTIFICATION_MAP.TryGetValue(domainEvent.GetType(), out var notificationType))
                    continue;

                // ReSharper disable once RedundantExplicitParamsArrayCreation
                var notification =
                    (IDomainEventNotification<IDomainEvent>) Activator.CreateInstance(notificationType!,
                        new object?[] { domainEvent, })!;

                notifications.Add(notification);
            }

            foreach (var notification in notifications)
                await _mediator.Publish(notification);
        }

        private IList<EntityBase> GetEntitiesFromContext()
        {
            return _context.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();
        }

        private static readonly IDictionary<Type, Type> EVENT_NOTIFICATION_MAP = new Dictionary<Type, Type>
        {
            [typeof(ParticipacaoAdicionadaEvent)] = typeof(ParticipacaoAdicionadaNotification)
        };
    }
}
