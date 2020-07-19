using Domain.Palestras;
using Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PalestraConfiguration : IEntityTypeConfiguration<Palestra>
    {
        public void Configure(EntityTypeBuilder<Palestra> builder)
        {
            builder.ToTable(nameof(Palestra));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName(nameof(Palestra) + "Id");

            builder.Property(x => x.PalestranteEmail)
                .HasConversion(new EmailToStringConverter());

            builder.Property(x => x.OrganizadorEmail)
                .HasConversion(new EmailToStringConverter());

            builder.Ignore(x => x.Participacoes);
        }
    }
}
