using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
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

        public async Task DispatchEvents()
        {
            var domainEntities = GetEntitiesFromContext();
            var domainEvents = domainEntities.SelectMany(x => x.DomainEvents).ToList();

            foreach (var entity in domainEntities)
                entity.ClearDomainEvents();

            var tasks = domainEvents.Select(domainEvent => _mediator.Publish(domainEvent));
            await Task.WhenAll(tasks);
        }

        private IList<EntityBase> GetEntitiesFromContext()
        {
            return _context.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();
        }
    }
}
