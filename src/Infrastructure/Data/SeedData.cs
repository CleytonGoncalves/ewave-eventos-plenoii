using System;
using Domain.Eventos;
using Domain.Funcionarios;
using Domain.Palestras;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        private static readonly PalestraId DEFAULT_PALESTRA_ID =
            new PalestraId(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Palestra>().HasData(new
            {
                Id = DEFAULT_PALESTRA_ID,
                Tema = "Desenvolvimento Backend",
                Titulo = "Arquitetura de Software com DDD",
                DataInicial = DateTimeOffset.Now,
                DataFinal = DateTimeOffset.Now + TimeSpan.FromHours(1),
                Local = Local.Bocaiuveira,
                Palestrante = "Martin Fowler",
                Status = StatusPalestra.Planejado,
            });

            builder.Entity<Funcionario>().HasData(new
            {
                Id = new FuncionarioId(new Guid("98EF415F-21F9-47A6-9100-8ECC75886422")),
                Nome = "Chefe do João",
                Email = new Email("boss@invalid.com"),
                RequerConfirmacaoSuperior = false,
            });

            builder.Entity<Funcionario>().HasData(new
            {
                Id = new FuncionarioId(new Guid("35999B04-656C-417B-A235-0B5C302E78D5")),
                Nome = "João",
                Email = new Email("peao@invalid.com"),
                RequerConfirmacaoSuperior = true,
                SuperiorId = new FuncionarioId(new Guid("98EF415F-21F9-47A6-9100-8ECC75886422")),
            });

            builder.Entity<Evento>().HasData(new
            {
                Id = new EventoId(new Guid("30EA5FC5-1EC9-4104-9D07-50BE51D002E7")),
                Titulo = "I Semana do Desenvolvedor Frontend",
                Descricao = "-- Nada concreto ainda --",
                Status = StatusEvento.Planejado
            });
        }
    }
}
