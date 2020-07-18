using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    #pragma warning disable 8618 // Non-nullable member is uninitialized -- DbSet é instanciado pelo EF
    public class PalestraContext : DbContext
    {
        public PalestraContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PalestraContext).Assembly);
        }
    }
    #pragma warning restore 8618 // Non-nullable member is uninitialized
}
