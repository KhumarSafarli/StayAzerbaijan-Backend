using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayAzerbaijan.Migrations
{
    public partial class ReservationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Reservations");
        }
    }
}
