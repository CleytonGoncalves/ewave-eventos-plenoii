using System.Threading.Tasks;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras
{
    public interface IPalestraRepository
    {
        /// <summary>
        /// Gets by Id
        /// </summary>
        /// <param name="id">Palestra ID</param>
        /// <returns>Palestra</returns>
        Task<Palestra?> GetBy(PalestraId id);

        /// <summary>
        /// Adds the palestra
        /// </summary>
        /// <param name="palestra">Palestra to be added</param>
        Task Add(Palestra palestra);
    }
}
