using Microsoft.EntityFrameworkCore.Migrations;

namespace mentionIT.Migrations
{
    public partial class MealImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealImage",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealImage",
                table: "Meal");
        }
    }
}
