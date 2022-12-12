using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppinglist_DAL.Migrations
{
    public partial class deletemanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductToDoList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductToDoList",
                columns: table => new
                {
                    ToDoListsID = table.Column<int>(type: "int", nullable: false),
                    productsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToDoList", x => new { x.ToDoListsID, x.productsID });
                    table.ForeignKey(
                        name: "FK_ProductToDoList_Products_productsID",
                        column: x => x.productsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToDoList_ToDoLists_ToDoListsID",
                        column: x => x.ToDoListsID,
                        principalTable: "ToDoLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductToDoList_productsID",
                table: "ProductToDoList",
                column: "productsID");
        }
    }
}
