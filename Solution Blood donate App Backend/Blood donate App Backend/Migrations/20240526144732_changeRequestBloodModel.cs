using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    public partial class changeRequestBloodModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestedContactNumber",
                table: "RequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedContactNumber",
                table: "RequestDetails");
        }
    }
}
