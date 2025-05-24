using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class adicionando_exclusao_logica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "excluido",
                table: "oficina",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "excluido_em",
                table: "oficina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "excluido",
                table: "manutencoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "excluido_em",
                table: "manutencoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "excluido",
                table: "carros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "excluido_em",
                table: "carros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "excluido",
                table: "oficina");

            migrationBuilder.DropColumn(
                name: "excluido_em",
                table: "oficina");

            migrationBuilder.DropColumn(
                name: "excluido",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "excluido_em",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "excluido",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "excluido_em",
                table: "carros");
        }
    }
}
