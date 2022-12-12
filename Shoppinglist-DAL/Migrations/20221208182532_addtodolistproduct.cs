using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppinglist_DAL.Migrations
{
    public partial class addtodolistproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductToDoLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ToDoListID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToDoLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductToDoLists_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToDoLists_ToDoLists_ToDoListID",
                        column: x => x.ToDoListID,
                        principalTable: "ToDoLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductToDoLists_ProductID",
                table: "ProductToDoLists",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToDoLists_ToDoListID",
                table: "ProductToDoLists",
                column: "ToDoListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductToDoLists");
        }
    }
}
