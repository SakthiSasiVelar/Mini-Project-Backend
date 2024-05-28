using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    public partial class changeInCenterAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CenterAdminRelations_CenterId",
                table: "CenterAdminRelations");

            migrationBuilder.CreateIndex(
                name: "IX_CenterAdminRelations_CenterId",
                table: "CenterAdminRelations",
                column: "CenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CenterAdminRelations_CenterId",
                table: "CenterAdminRelations");

            migrationBuilder.CreateIndex(
                name: "IX_CenterAdminRelations_CenterId",
                table: "CenterAdminRelations",
                column: "CenterId",
                unique: true);
        }
    }
}
