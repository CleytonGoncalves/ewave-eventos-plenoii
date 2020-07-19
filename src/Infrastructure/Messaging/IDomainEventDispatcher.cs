using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public interface IDomainEventDispatcher
    {
        Task DispatchEvents();
    }
}
