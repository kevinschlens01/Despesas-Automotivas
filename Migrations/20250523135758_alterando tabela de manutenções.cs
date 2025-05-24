using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class alterandotabelademanutenções : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_entrada",
                table: "manutencoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "data_saida",
                table: "manutencoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "hora_entrada",
                table: "manutencoes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "hora_saida",
                table: "manutencoes",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pecas_substituidas",
                table: "manutencoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "servicos_executados",
                table: "manutencoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "valor_total_pecas",
                table: "manutencoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "valor_total_servicos",
                table: "manutencoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "cor",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_entrada",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "data_saida",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "hora_entrada",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "hora_saida",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "pecas_substituidas",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "servicos_executados",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "valor_total_pecas",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "valor_total_servicos",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "cor",
                table: "carros");
        }
    }
}
