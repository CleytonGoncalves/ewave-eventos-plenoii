using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Funcionarios;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly PalestraContext _context;

        public FuncionarioRepository(PalestraContext context)
        {
            _context = context;
        }

        public Task Add(Funcionario palestra)
        {
            _context.Add(palestra);

            return Task.CompletedTask;
        }

        public Task Update(Funcionario palestra)
        {
            _context.Update(palestra);

            return Task.CompletedTask;
        }

        public async Task<bool> Exists(FuncionarioId id, CancellationToken cancellationToken = default) =>
            await _context.Funcionarios.AnyAsync(p => p.Id == id, cancellationToken);

        public async Task<Funcionario> GetBy(FuncionarioId id, CancellationToken cancellationToken = default) =>
            await FindBy(id, cancellationToken) ?? throw new InvalidOperationException("Id Not Found");

        public async Task<Funcionario?> FindBy(FuncionarioId id, CancellationToken cancellationToken = default) =>
            await _context.Funcionarios.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public Funcionario? FindBy(Email email) =>
            _context.Funcionarios.FirstOrDefault(p => p.Email == email);
    }
}
