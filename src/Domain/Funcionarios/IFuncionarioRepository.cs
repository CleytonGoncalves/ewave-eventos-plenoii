using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedKernel;

namespace Domain.Funcionarios
{
    public interface IFuncionarioRepository
    {
        /// <summary> Adiciona Funcionário </summary>
        Task Add(Funcionario funcionario);

        /// <summary> Atualiza Funcionário </summary>
        Task Update(Funcionario funcionario);

        /// <summary> Verifica se existe alguma entidade com o ID </summary>
        Task<bool> Exists(FuncionarioId id, CancellationToken cancellationToken = default);

        /// <summary> Busca por ID </summary>
        /// <exception cref="InvalidOperationException">Se o ID não existir</exception>
        /// <remarks>
        /// Se é esperado que possa não existir, usar <see cref="FindBy(Domain.Funcionarios.FuncionarioId,System.Threading.CancellationToken)"/>
        /// </remarks>
        /// <returns>Funcionário</returns>
        Task<Funcionario> GetBy(FuncionarioId id, CancellationToken cancellationToken = default);

        /// <summary> Busca por ID </summary>
        /// <returns>O funcionário com aquele email, se houver. Caso contrário, null.</returns>
        Task<Funcionario?> FindBy(FuncionarioId id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Busca funcionarios em um determinado local naquele horário específico
        /// </summary>
        /// <returns>O funcionário com aquele email, se houver. Caso contrário, null.</returns>
        Funcionario? FindBy(Email email);
    }
}
