using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Author", "RecipeName" },
                values: new object[] { 1L, "Mike", "Alfrado" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Author", "RecipeName" },
                values: new object[] { 2L, "Jake", "Tomato Soup" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Author", "RecipeName" },
                values: new object[] { 3L, "Paul", "Spicy Honey Wings" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "ItemAmount", "ItemName", "RecipeId" },
                values: new object[,]
                {
                    { 1L, "20 grams", "Chicken Thighs", 1L },
                    { 2L, "15 grams", "Milk", 1L },
                    { 3L, "6 grams", "Tomatoes", 2L },
                    { 4L, "10 grams", "Bread", 2L },
                    { 5L, "40 grams", "Chicken Wings", 3L },
                    { 6L, "6 grams", "Honey", 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
