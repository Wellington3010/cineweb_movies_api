using Microsoft.EntityFrameworkCore.Migrations;

namespace cineweb_movies_api.Migrations
{
    public partial class UpdatingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_FilmeId",
                table: "ingresso_pedido",
                column: "FilmeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_pedido_IngressoId",
                table: "ingresso_pedido",
                column: "IngressoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingresso_FilmeId",
                table: "ingresso",
                column: "FilmeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresso_filme_FilmeId",
                table: "ingresso",
                column: "FilmeId",
                principalTable: "filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresso_pedido_filme_FilmeId",
                table: "ingresso_pedido",
                column: "FilmeId",
                principalTable: "filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresso_pedido_ingresso_IngressoId",
                table: "ingresso_pedido",
                column: "IngressoId",
                principalTable: "ingresso",
                principalColumn: "IdIngresso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingresso_filme_FilmeId",
                table: "ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresso_pedido_filme_FilmeId",
                table: "ingresso_pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresso_pedido_ingresso_IngressoId",
                table: "ingresso_pedido");

            migrationBuilder.DropIndex(
                name: "IX_ingresso_pedido_FilmeId",
                table: "ingresso_pedido");

            migrationBuilder.DropIndex(
                name: "IX_ingresso_pedido_IngressoId",
                table: "ingresso_pedido");

            migrationBuilder.DropIndex(
                name: "IX_ingresso_FilmeId",
                table: "ingresso");
        }
    }
}
