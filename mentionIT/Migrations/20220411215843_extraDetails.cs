using Microsoft.EntityFrameworkCore.Migrations;

namespace mentionIT.Migrations
{
    public partial class extraDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipeSteps",
                table: "Meal",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "RecipeSteps",
                table: "Meal");
        }
    }
}
