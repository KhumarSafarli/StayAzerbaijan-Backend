using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayAzerbaijan.Migrations
{
    public partial class addedWeekendAvailabilityz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableOnWeekend",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailableOnWeekend",
                table: "Hotels");
        }
    }
}
