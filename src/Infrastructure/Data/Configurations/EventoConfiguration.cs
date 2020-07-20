using Domain.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable(nameof(Evento));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName(nameof(Evento) + "Id");
        }
    }
}
