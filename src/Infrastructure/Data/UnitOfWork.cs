using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Infrastructure.Processing;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PalestraContext _context;
        private readonly IDomainEventDispatcher _eventDispatcher;

        private bool _disposed;

        public UnitOfWork(PalestraContext context, IDomainEventDispatcher eventDispatcher)
        {
            _context = context;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<int> Commit(CancellationToken cToken = default)
        {
            await _eventDispatcher.DispatchEvents();

            int affectedRows = _context.SaveChanges();

            return affectedRows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (! _disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}
