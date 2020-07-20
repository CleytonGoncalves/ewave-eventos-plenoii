using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class FuncionarioEmailSuperior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Funcionario_SuperiorId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_SuperiorId",
                table: "Funcionario");

            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "FuncionarioId",
                keyValue: new Guid("98ef415f-21f9-47a6-9100-8ecc75886422"));

            migrationBuilder.DropColumn(
                name: "RequerConfirmacaoSuperior",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "SuperiorId",
                table: "Funcionario");

            migrationBuilder.AddColumn<string>(
                name: "SuperiorEmail",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Funcionario",
                keyColumn: "FuncionarioId",
                keyValue: new Guid("35999b04-656c-417b-a235-0b5c302e78d5"),
                columns: new[] { "Email", "SuperiorEmail" },
                values: new object[] { "joao@example.com", "boss@example.com" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Email", "Nome", "SuperiorEmail" },
                values: new object[] { new Guid("4fc14a28-83c5-47bc-8b24-df741caa9f7d"), "maria@example.com", "Maria", null! });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "FuncionarioId",
                keyValue: new Guid("4fc14a28-83c5-47bc-8b24-df741caa9f7d"));

            migrationBuilder.DropColumn(
                name: "SuperiorEmail",
                table: "Funcionario");

            migrationBuilder.AddColumn<bool>(
                name: "RequerConfirmacaoSuperior",
                table: "Funcionario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperiorId",
                table: "Funcionario",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Email", "Nome", "RequerConfirmacaoSuperior", "SuperiorId" },
                values: new object[] { new Guid("98ef415f-21f9-47a6-9100-8ecc75886422"), "boss@invalid.com", "Chefe do João", false, null! });

            migrationBuilder.UpdateData(
                table: "Funcionario",
                keyColumn: "FuncionarioId",
                keyValue: new Guid("35999b04-656c-417b-a235-0b5c302e78d5"),
                columns: new[] { "Email", "RequerConfirmacaoSuperior", "SuperiorId" },
                values: new object[] { "peao@invalid.com", true, new Guid("98ef415f-21f9-47a6-9100-8ecc75886422") });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_SuperiorId",
                table: "Funcionario",
                column: "SuperiorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Funcionario_SuperiorId",
                table: "Funcionario",
                column: "SuperiorId",
                principalTable: "Funcionario",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
