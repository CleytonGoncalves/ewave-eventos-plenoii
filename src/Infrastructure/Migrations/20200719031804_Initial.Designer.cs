﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PalestraContext))]
    [Migration("20200719031804_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Eventos.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("EventoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Evento");

                    b.HasData(
                        new
                        {
                            Id = new Guid("30ea5fc5-1ec9-4104-9d07-50be51d002e7"),
                            Descricao = "-- Nada concreto ainda --",
                            Status = 10,
                            Titulo = "I Semana do Desenvolvedor Frontend"
                        });
                });

            modelBuilder.Entity("Domain.Funcionarios.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("FuncionarioId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("RequerConfirmacaoSuperior")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SuperiorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SuperiorId");

                    b.ToTable("Funcionario");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98ef415f-21f9-47a6-9100-8ecc75886422"),
                            Email = "boss@invalid.com",
                            Nome = "Chefe do João",
                            RequerConfirmacaoSuperior = false
                        },
                        new
                        {
                            Id = new Guid("35999b04-656c-417b-a235-0b5c302e78d5"),
                            Email = "peao@invalid.com",
                            Nome = "João",
                            RequerConfirmacaoSuperior = true,
                            SuperiorId = new Guid("98ef415f-21f9-47a6-9100-8ecc75886422")
                        });
                });

            modelBuilder.Entity("Domain.Palestras.Palestra", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("PalestraId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DataFinal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DataInicial")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Local")
                        .HasColumnType("integer");

                    b.Property<string>("Palestrante")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Palestra");

                    b.HasData(
                        new
                        {
                            Id = new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                            DataFinal = new DateTimeOffset(new DateTime(2020, 7, 19, 0, 18, 4, 474, DateTimeKind.Unspecified).AddTicks(3737), new TimeSpan(0, -4, 0, 0, 0)),
                            DataInicial = new DateTimeOffset(new DateTime(2020, 7, 18, 23, 18, 4, 471, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, -4, 0, 0, 0)),
                            Local = 30,
                            Palestrante = "Martin Fowler",
                            Status = 10,
                            Tema = "Desenvolvimento Backend",
                            Titulo = "Arquitetura de Software com DDD"
                        });
                });

            modelBuilder.Entity("Domain.Funcionarios.Funcionario", b =>
                {
                    b.HasOne("Domain.Funcionarios.Funcionario", "Superior")
                        .WithMany()
                        .HasForeignKey("SuperiorId");

                    b.OwnsMany("Domain.Funcionarios.Participacoes.Participacao", "Participacoes", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnName("FuncionarioId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("FuncionarioId")
                                .HasColumnName("Participacao_FuncionarioId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("PalestraId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Status")
                                .HasColumnType("integer");

                            b1.HasKey("Id");

                            b1.HasIndex("FuncionarioId", "PalestraId")
                                .IsUnique();

                            b1.ToTable("Participacao");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
