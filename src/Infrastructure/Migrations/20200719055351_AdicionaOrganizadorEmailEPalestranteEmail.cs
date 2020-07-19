using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AdicionaOrganizadorEmailEPalestranteEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Palestrante",
                table: "Palestra");

            migrationBuilder.AddColumn<string>(
                name: "OrganizadorEmail",
                table: "Palestra",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PalestranteEmail",
                table: "Palestra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PalestranteNome",
                table: "Palestra",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Palestra",
                keyColumn: "PalestraId",
                keyValue: new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                columns: new[] { "DataFinal", "DataInicial", "OrganizadorEmail", "PalestranteEmail", "PalestranteNome" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 7, 19, 2, 53, 51, 127, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 7, 19, 1, 53, 51, 125, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, -4, 0, 0, 0)), "organizador@invalid.com", "martin@invalid.com", "Martin Fowler" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizadorEmail",
                table: "Palestra");

            migrationBuilder.DropColumn(
                name: "PalestranteEmail",
                table: "Palestra");

            migrationBuilder.DropColumn(
                name: "PalestranteNome",
                table: "Palestra");

            migrationBuilder.AddColumn<string>(
                name: "Palestrante",
                table: "Palestra",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Palestra",
                keyColumn: "PalestraId",
                keyValue: new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"),
                columns: new[] { "DataFinal", "DataInicial", "Palestrante" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 7, 19, 0, 18, 4, 474, DateTimeKind.Unspecified).AddTicks(3737), new TimeSpan(0, -4, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 7, 18, 23, 18, 4, 471, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, -4, 0, 0, 0)), "Martin Fowler" });
        }
    }
}
