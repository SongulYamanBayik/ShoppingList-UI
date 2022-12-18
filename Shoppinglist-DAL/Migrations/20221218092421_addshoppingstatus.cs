using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppinglist_DAL.Migrations
{
    public partial class addshoppingstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShoppingStatus",
                table: "ToDoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingStatus",
                table: "ToDoLists");
        }
    }
}
