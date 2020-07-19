using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MoveParticipacaoParaPalestra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participacao_Funcionario_Participacao_FuncionarioId",
                table: "Participacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participacao",
                table: "Participacao");

            migrationBuilder.DropIndex(
                name: "IX_Participacao_Participacao_FuncionarioId_PalestraId",
                table: "Participacao");

            migrationBuilder.DropColumn(
                name: "Participacao_FuncionarioId",
                table: "Participacao");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipacaoId",
                table: "Participacao",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participacao",
                table: "Participacao",
                column: "ParticipacaoId");

            migrationBuilder.UpdateData(
                table: "Palestra",
                keyColumn: "PalestraId",
                keyValue: new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                columns: new[] { "DataFinal", "DataInicial" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 9, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 9, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_PalestraId",
                table: "Participacao",
                column: "PalestraId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_FuncionarioId_PalestraId",
                table: "Participacao",
                columns: new[] { "FuncionarioId", "PalestraId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacao_Palestra_PalestraId",
                table: "Participacao",
                column: "PalestraId",
                principalTable: "Palestra",
                principalColumn: "PalestraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participacao_Palestra_PalestraId",
                table: "Participacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participacao",
                table: "Participacao");

            migrationBuilder.DropIndex(
                name: "IX_Participacao_PalestraId",
                table: "Participacao");

            migrationBuilder.DropIndex(
                name: "IX_Participacao_FuncionarioId_PalestraId",
                table: "Participacao");

            migrationBuilder.DropColumn(
                name: "ParticipacaoId",
                table: "Participacao");

            migrationBuilder.AddColumn<Guid>(
                name: "Participacao_FuncionarioId",
                table: "Participacao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participacao",
                table: "Participacao",
                column: "FuncionarioId");

            migrationBuilder.UpdateData(
                table: "Palestra",
                keyColumn: "PalestraId",
                keyValue: new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                columns: new[] { "DataFinal", "DataInicial" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 7, 19, 2, 53, 51, 127, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 7, 19, 1, 53, 51, 125, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, -4, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_Participacao_FuncionarioId_PalestraId",
                table: "Participacao",
                columns: new[] { "Participacao_FuncionarioId", "PalestraId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacao_Funcionario_Participacao_FuncionarioId",
                table: "Participacao",
                column: "Participacao_FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
