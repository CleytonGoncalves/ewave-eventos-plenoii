using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PalestraContext _context;
        private bool _disposed;

        public UnitOfWork(PalestraContext context)
        {
            _context = context;
        }

        public async Task<int> Commit(CancellationToken cToken = default)
        {
            int affectedRows = await _context
                .SaveChangesAsync(cToken)
                .ConfigureAwait(false);

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
