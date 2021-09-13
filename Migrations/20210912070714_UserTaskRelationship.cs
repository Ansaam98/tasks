using Microsoft.EntityFrameworkCore.Migrations;

namespace tasks.Migrations
{
    public partial class UserTaskRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Userid",
                table: "Tasks",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_Userid",
                table: "Tasks",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_Userid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_Userid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Tasks");
        }
    }
}
