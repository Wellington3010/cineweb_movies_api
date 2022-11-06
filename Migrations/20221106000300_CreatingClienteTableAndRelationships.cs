using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace cineweb_movies_api.Migrations
{
    public partial class CreatingClienteTableAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_IdCliente",
                table: "pedido",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_IdCliente",
                table: "pedido",
                column: "IdCliente",
                principalTable: "cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_IdCliente",
                table: "pedido");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropIndex(
                name: "IX_pedido_IdCliente",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "pedido");
        }
    }
}
