using Microsoft.EntityFrameworkCore.Migrations;

namespace cineweb_movies_api.Migrations
{
    public partial class Creating_Quantidade_Property_On_Ingresso_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ingresso");
        }
    }
}
