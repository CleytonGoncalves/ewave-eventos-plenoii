using System.Linq;
using System.Threading.Tasks;
using Domain.Palestras;
using Domain.Palestras.ValueObjects;

namespace Infrastructure.Data.Repositories
{
    public class PalestraRepository : IPalestraRepository
    {
        private readonly PalestraContext _context;

        public PalestraRepository(PalestraContext context)
        {
            _context = context;
        }

        public Task<Palestra?> GetBy(PalestraId id)
        {
            var palestra = _context.Palestras.FirstOrDefault(p => p.Id == id);

            return Task.FromResult<Palestra?>(palestra);
        }

        public Task Add(Palestra palestra)
        {
            _context.Add(palestra);

            return Task.CompletedTask;
        }
    }
}
