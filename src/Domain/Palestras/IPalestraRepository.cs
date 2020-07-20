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
        /// Adiciona a Palestra
        /// </summary>
        /// <param name="palestra">Palestra a ser adicionada</param>
        Task Add(Palestra palestra);

        /// <summary>
        /// Atualiza a Palestra
        /// </summary>
        /// <param name="palestra">Palestra a ser atualizada</param>
        Task Update(Palestra palestra);

        /// <summary>
        /// Verifica se existe alguma entidade com o ID
        /// </summary>
        /// <param name="id">ID a ser verificado</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True, se já existir. Caso contrário, False</returns>
        Task<bool> Exists(PalestraId id, CancellationToken cancellationToken = default);

        /// <summary> Busca por ID </summary>
        /// <exception cref="InvalidOperationException">Se o ID não existir</exception>
        /// <remarks>
        /// Se é esperado que possa não existir, usar <see cref="FindBy(Domain.Palestras.ValueObjects.PalestraId,System.Threading.CancellationToken)"/>/>
        /// </remarks>
        Task<Palestra> GetBy(PalestraId id, CancellationToken cancellationToken = default);

        /// <summary> Busca por ID </summary>
        Task<Palestra?> FindBy(PalestraId id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Busca palestras em um determinado local naquele horário específico
        /// </summary>
        ICollection<Palestra> FindBy(Local local, DateTimeOffset dataInicial, DateTimeOffset dataFinal);
    }
}
