using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Palestras.ValueObjects;

namespace Domain.Palestras
{
    public interface IPalestraRepository
    {
        /// <summary>
        /// Busca por ID
        /// </summary>
        /// <param name="id">Palestra ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Palestra</returns>
        Task<Palestra?> GetBy(PalestraId id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adiciona a Palestra
        /// </summary>
        /// <param name="palestra">Palestra to be added</param>
        Task Add(Palestra palestra);

        /// <summary>
        /// Busca palestras em um determinado local naquele horário específico
        /// </summary>
        ICollection<Palestra> FindBy(Local local, DateTimeOffset dataInicial, DateTimeOffset dataFinal);
    }
}
