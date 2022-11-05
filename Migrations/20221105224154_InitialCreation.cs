using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace cineweb_movies_api.Migrations
{
    public partial class InitialCreation : Migration
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
                name: "ingresso",
                columns: table => new
                {
                    IdIngresso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresso", x => x.IdIngresso);
                    table.ForeignKey(
                        name: "FK_ingresso_filme_filme",
                        column: x => x.filme,
                        principalTable: "filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingresso_pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pedido = table.Column<int>(type: "int", nullable: true),
                    filme = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    ingresso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresso_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingresso_pedido_filme_filme",
                        column: x => x.filme,
                        principalTable: "filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingresso_pedido_ingresso_ingresso",
                        column: x => x.ingresso,
                        principalTable: "ingresso",
                        principalColumn: "IdIngresso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingresso_pedido_pedido_pedido",
                        column: x => x.pedido,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_filme",
                table: "ingresso",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_filme",
                table: "ingresso_pedido",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_ingresso",
                table: "ingresso_pedido",
                column: "ingresso");

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_pedido",
                table: "ingresso_pedido",
                column: "pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingresso_pedido");

            migrationBuilder.DropTable(
                name: "ingresso");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "filme");
        }
    }
}
