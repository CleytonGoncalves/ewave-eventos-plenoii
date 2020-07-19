using System.Threading;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IUnitOfWork
    {
        /// <summary> Concretiza todas as mudanças de uma vez só (database changes) </summary>
        /// <returns>Quantidade de linhas afetadas</returns>
        Task<int> Commit(CancellationToken cToken = default);
    }
}
