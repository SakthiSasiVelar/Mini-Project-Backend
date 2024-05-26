using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    public partial class addPropertyInrequestBlood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "RequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "RequestDetails");
        }
    }
}
