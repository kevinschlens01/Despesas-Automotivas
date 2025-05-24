using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class alterandotabelademanutenções2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_servico",
                table: "manutencoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_servico",
                table: "manutencoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
