using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class adicionandotabelademelhorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "melhorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_peca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carro_id = table.Column<int>(type: "int", nullable: false),
                    adicionado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    periodo_avaliado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false),
                    excluido_em = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_melhorias", x => x.id);
                    table.ForeignKey(
                        name: "FK_melhorias_carros_carro_id",
                        column: x => x.carro_id,
                        principalTable: "carros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_melhorias_carro_id",
                table: "melhorias",
                column: "carro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "melhorias");
        }
    }
}
