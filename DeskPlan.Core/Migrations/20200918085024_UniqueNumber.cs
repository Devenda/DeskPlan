using Microsoft.EntityFrameworkCore.Migrations;

namespace DeskPlan.Core.Migrations
{
    public partial class UniqueNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Number",
                table: "User",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Number",
                table: "User");
        }
    }
}
