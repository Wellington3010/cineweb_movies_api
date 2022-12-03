using Microsoft.EntityFrameworkCore.Migrations;

namespace cineweb_movies_api.Migrations
{
    public partial class RemocaoPropriedadeCapa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capa",
                table: "filme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capa",
                table: "filme",
                type: "text",
                nullable: true);
        }
    }
}
