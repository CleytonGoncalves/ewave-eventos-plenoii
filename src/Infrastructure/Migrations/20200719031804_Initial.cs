using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    EventoId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    SuperiorId = table.Column<Guid>(nullable: true),
                    RequerConfirmacaoSuperior = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Funcionario_SuperiorId",
                        column: x => x.SuperiorId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palestra",
                columns: table => new
                {
                    PalestraId = table.Column<Guid>(nullable: false),
                    Tema = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    DataInicial = table.Column<DateTimeOffset>(nullable: false),
                    DataFinal = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Local = table.Column<int>(nullable: false),
                    Palestrante = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestra", x => x.PalestraId);
                });

            migrationBuilder.CreateTable(
                name: "Participacao",
                columns: table => new
                {
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    PalestraId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Participacao_FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participacao", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Participacao_Funcionario_Participacao_FuncionarioId",
                        column: x => x.Participacao_FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Evento",
                columns: new[] { "EventoId", "Descricao", "Status", "Titulo" },
                values: new object[] { new Guid("30ea5fc5-1ec9-4104-9d07-50be51d002e7"), "-- Nada concreto ainda --", 10, "I Semana do Desenvolvedor Frontend" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Email", "Nome", "RequerConfirmacaoSuperior", "SuperiorId" },
                values: new object[] { new Guid("98ef415f-21f9-47a6-9100-8ecc75886422"), "boss@invalid.com", "Chefe do João", false, null! });

            migrationBuilder.InsertData(
                table: "Palestra",
                columns: new[] { "PalestraId", "DataFinal", "DataInicial", "Local", "Palestrante", "Status", "Tema", "Titulo" },
                values: new object[] { new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"), new DateTimeOffset(new DateTime(2020, 7, 19, 0, 18, 4, 474, DateTimeKind.Unspecified).AddTicks(3737), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 7, 18, 23, 18, 4, 471, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, -4, 0, 0, 0)), 30, "Martin Fowler", 10, "Desenvolvimento Backend", "Arquitetura de Software com DDD" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Email", "Nome", "RequerConfirmacaoSuperior", "SuperiorId" },
                values: new object[] { new Guid("35999b04-656c-417b-a235-0b5c302e78d5"), "peao@invalid.com", "João", true, new Guid("98ef415f-21f9-47a6-9100-8ecc75886422") });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_SuperiorId",
                table: "Funcionario",
                column: "SuperiorId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_Participacao_FuncionarioId_PalestraId",
                table: "Participacao",
                columns: new[] { "Participacao_FuncionarioId", "PalestraId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Palestra");

            migrationBuilder.DropTable(
                name: "Participacao");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
