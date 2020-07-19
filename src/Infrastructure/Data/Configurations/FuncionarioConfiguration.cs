using Domain.Funcionarios;
using Domain.Funcionarios.Participacoes;
using Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable(nameof(Funcionario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName(nameof(Funcionario) + "Id");

            builder.HasOne(x => x.Superior);

            builder.Property(x => x.Email)
                .HasConversion(new EmailToStringConverter());

            builder.OwnsMany(x => x.Participacoes, ParticipacaoConfiguration);
        }

        private void ParticipacaoConfiguration(OwnedNavigationBuilder<Funcionario, Participacao> participacaoBuilder)
        {
            participacaoBuilder.ToTable(nameof(Participacao));

            participacaoBuilder.HasKey(x => x.Id);
            participacaoBuilder.Property(x => x.Id)
                .HasColumnName(nameof(Funcionario) + "Id");

            participacaoBuilder.HasIndex("FuncionarioId", "PalestraId")
                .IsUnique();
        }
    }
}
