using Microsoft.EntityFrameworkCore.Migrations;

namespace mentionIT.Migrations
{
    public partial class LikesUserLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikesUserLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikesUserLink", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LikesUserLink",
                columns: new[] { "Id", "Liked", "MealId", "Name" },
                values: new object[] { 1, true, 1, "nkeerthimeher@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikesUserLink");
        }
    }
}
