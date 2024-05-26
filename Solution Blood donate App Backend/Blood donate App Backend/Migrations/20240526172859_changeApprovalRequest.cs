using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    public partial class changeApprovalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved_Request",
                table: "RequestDetails");

            migrationBuilder.AddColumn<string>(
                name: "RequestApprovalStatus",
                table: "RequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestApprovalStatus",
                table: "RequestDetails");

            migrationBuilder.AddColumn<bool>(
                name: "Approved_Request",
                table: "RequestDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
