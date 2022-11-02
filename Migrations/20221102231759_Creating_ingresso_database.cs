using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace cineweb_movies_api.Migrations
{
    public partial class Creating_ingresso_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movie");

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
                    IdFilme = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    FilmeId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresso", x => x.IdIngresso);
                    table.ForeignKey(
                        name: "FK_ingresso_filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_FilmeId",
                table: "ingresso",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingresso");

            migrationBuilder.DropTable(
                name: "filme");

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    HomeMovie = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MoviePoster = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    Sinopse = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.Id);
                });
        }
    }
}
