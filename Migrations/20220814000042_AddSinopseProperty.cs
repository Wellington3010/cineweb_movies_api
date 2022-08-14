using Microsoft.EntityFrameworkCore.Migrations;

namespace cineweb_movies_api.Migrations
{
    public partial class AddSinopseProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sinopse",
                table: "movie",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sinopse",
                table: "movie");
        }
    }
}
