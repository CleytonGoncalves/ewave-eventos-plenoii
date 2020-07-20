using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public interface IDomainEventDispatcher
    {
        Task DispatchEvents();
    }
}
