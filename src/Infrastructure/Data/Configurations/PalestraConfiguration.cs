using Domain.Palestras;
using Domain.Palestras.Participacoes;
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

            builder.OwnsMany(x => x.Participacoes, ParticipacaoConfiguration);
        }

        private void ParticipacaoConfiguration(OwnedNavigationBuilder<Palestra, Participacao> participacaoBuilder)
        {
            participacaoBuilder.ToTable(nameof(Participacao));

            participacaoBuilder.HasKey(x => x.Id);
            participacaoBuilder.Property(x => x.Id)
                .HasColumnName(nameof(Participacao) + "Id");

            participacaoBuilder.WithOwner().HasPrincipalKey(x => x.Id);

            participacaoBuilder.HasIndex(nameof(Participacao.FuncionarioId), $"{nameof(Palestra)}Id")
                .IsUnique();
        }
    }
}
