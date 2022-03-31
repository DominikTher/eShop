using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Persistence.DataAccess.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "SOLID principles book", "solid.jpg", "SOLID", 11m },
                    { 2, ".NET Book", "net.jpg", ".NET", 12m },
                    { 3, null, "csharp.jpg", "C#", 13m },
                    { 4, null, "cqrs.jpg", "CQRS", 14m },
                    { 5, null, "onion.jpg", "Clean Architecture", 15m },
                    { 6, null, "tests.jpg", "Tests", 16m },
                    { 7, null, "designpatterns.jpg", "Design Patterns", 17m },
                    { 8, null, "api.jpg", "Api", 18m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
