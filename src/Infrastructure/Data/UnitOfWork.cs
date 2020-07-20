using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Infrastructure.Messaging;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PalestraContext _context;
        private readonly IDomainEventDispatcher _eventDispatcher;

        public UnitOfWork(PalestraContext context, IDomainEventDispatcher eventDispatcher)
        {
            _context = context;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<int> Commit(CancellationToken cToken = default)
        {
            var events = await _eventDispatcher.DispatchEvents();

            int affectedRows = _context.SaveChanges();

            await _eventDispatcher.DispatchNotifications(events);

            return affectedRows;
        }
    }
}
