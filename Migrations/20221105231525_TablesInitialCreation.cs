using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace cineweb_movies_api.Migrations
{
    public partial class TablesInitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filme",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    Poster = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    Sinopse = table.Column<string>(type: "text", nullable: false),
                    HomeMovie = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingresso",
                columns: table => new
                {
                    IdIngresso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresso", x => x.IdIngresso);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ValorTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingresso_pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IngressoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresso_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingresso_pedido_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_PedidoId",
                table: "ingresso_pedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filme");

            migrationBuilder.DropTable(
                name: "ingresso");

            migrationBuilder.DropTable(
                name: "ingresso_pedido");

            migrationBuilder.DropTable(
                name: "pedido");
        }
    }
}
