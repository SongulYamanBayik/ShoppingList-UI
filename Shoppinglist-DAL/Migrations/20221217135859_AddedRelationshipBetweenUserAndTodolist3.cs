using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppinglist_DAL.Migrations
{
    public partial class AddedRelationshipBetweenUserAndTodolist3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "ToDoLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_AppUserID",
                table: "ToDoLists",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_AspNetUsers_AppUserID",
                table: "ToDoLists",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_AspNetUsers_AppUserID",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_AppUserID",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "ToDoLists");
        }
    }
}
