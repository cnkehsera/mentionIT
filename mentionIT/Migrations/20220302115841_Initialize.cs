using Microsoft.EntityFrameworkCore.Migrations;

namespace mentionIT.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "Comments", "Cuisine", "Likes", "Name", "YLink" },
                values: new object[,]
                {
                    { 1, "", "Italian", 3, "Chicken Scarpariello", "https://www.youtube.com/results?search_query=italian+recipes+for+dinner" },
                    { 2, "", "Indian", 3, "Mughlai Chicken Handi", "https://www.youtube.com/watch?v=u66pG73UroY" },
                    { 3, "", "Lebanese", 3, "Lebanese Chicken", "https://www.youtube.com/watch?v=EwYGQ9Rx53w" },
                    { 4, "", "Portuguese", 3, "Cataplana ", "https://www.youtube.com/watch?v=utv-GpSJypk" },
                    { 5, "", "Pakistani", 3, "Karahi chicken", "https://www.youtube.com/watch?v=RBS-ptrMAgI" },
                    { 6, "", "French", 3, "Cassoulet", "https://www.youtube.com/watch?v=nKGsoQM5YJk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal");
        }
    }
}
