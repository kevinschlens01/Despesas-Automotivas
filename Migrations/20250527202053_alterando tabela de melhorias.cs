using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class alterandotabelademelhorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "melhorias");

            migrationBuilder.DropColumn(
                name: "periodo_avaliado",
                table: "melhorias");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "melhorias");

            migrationBuilder.RenameColumn(
                name: "adicionado_em",
                table: "melhorias",
                newName: "data_avaliacao");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "melhorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "melhorias");

            migrationBuilder.RenameColumn(
                name: "data_avaliacao",
                table: "melhorias",
                newName: "adicionado_em");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "melhorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "periodo_avaliado",
                table: "melhorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                table: "melhorias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
