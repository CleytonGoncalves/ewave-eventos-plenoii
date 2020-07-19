using Domain.Eventos;
using Domain.Funcionarios;
using Domain.Palestras;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized -- DbSet é instanciado pelo EF
    public class PalestraContext : DbContext
    {
        public PalestraContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PalestraContext).Assembly);

            builder.Seed();
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Palestra> Palestras { get; set; }
    }
    #pragma warning restore 8618 // Non-nullable member is uninitialized
}
