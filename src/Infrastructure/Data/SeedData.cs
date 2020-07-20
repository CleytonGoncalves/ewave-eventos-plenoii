using System;
using Domain.Eventos;
using Domain.Funcionarios;
using Domain.Palestras;
using Domain.Palestras.ValueObjects;
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
                DataInicial = new DateTimeOffset(2020, 09, 01, 13, 30, 00, TimeSpan.FromHours(-4)),
                DataFinal = new DateTimeOffset(2020, 09, 01, 14, 30, 00, TimeSpan.FromHours(-4)),
                Local = Local.Bocaiuveira,
                PalestranteNome = "Martin Fowler",
                PalestranteEmail = new Email("martin@invalid.com"),
                OrganizadorEmail = new Email("organizador@invalid.com"),
                Status = StatusPalestra.Planejado,
            });

            builder.Entity<Funcionario>().HasData(new
            {
                Id = new FuncionarioId(new Guid("35999B04-656C-417B-A235-0B5C302E78D5")),
                Nome = "João",
                Email = new Email("joao@example.com"),
                SuperiorEmail = new Email("boss@example.com")
            });

            builder.Entity<Funcionario>().HasData(new
            {
                Id = new FuncionarioId(new Guid("4FC14A28-83C5-47BC-8B24-DF741CAA9F7D")),
                Nome = "Maria",
                Email = new Email("maria@example.com"),
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
