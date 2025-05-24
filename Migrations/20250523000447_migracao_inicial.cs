using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasAutomotivas.Migrations
{
    /// <inheritdoc />
    public partial class migracao_inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    versao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quilometragem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oficina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oficina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manutencoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carro_id = table.Column<int>(type: "int", nullable: false),
                    oficina_id = table.Column<int>(type: "int", nullable: false),
                    data_servico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descricao_servico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_manutencoes_carros_carro_id",
                        column: x => x.carro_id,
                        principalTable: "carros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manutencoes_oficina_oficina_id",
                        column: x => x.oficina_id,
                        principalTable: "oficina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_manutencoes_carro_id",
                table: "manutencoes",
                column: "carro_id");

            migrationBuilder.CreateIndex(
                name: "IX_manutencoes_oficina_id",
                table: "manutencoes",
                column: "oficina_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manutencoes");

            migrationBuilder.DropTable(
                name: "carros");

            migrationBuilder.DropTable(
                name: "oficina");
        }
    }
}
