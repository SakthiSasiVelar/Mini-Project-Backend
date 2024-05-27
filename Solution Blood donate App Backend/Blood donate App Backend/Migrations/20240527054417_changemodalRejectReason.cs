using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    public partial class changemodalRejectReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "RequestDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "RequestDetails");
        }
    }
}
