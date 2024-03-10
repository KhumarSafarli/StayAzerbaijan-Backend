using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayAzerbaijan.Migrations
{
    public partial class TransferTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelCategory_Category_CategoryId",
                table: "HotelCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelCategory_Hotels_HotelId",
                table: "HotelCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelCategory",
                table: "HotelCategory");

            migrationBuilder.RenameTable(
                name: "HotelCategory",
                newName: "HotelCategories");

            migrationBuilder.RenameIndex(
                name: "IX_HotelCategory_HotelId",
                table: "HotelCategories",
                newName: "IX_HotelCategories_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelCategory_CategoryId",
                table: "HotelCategories",
                newName: "IX_HotelCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelCategories",
                table: "HotelCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaxCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelCategories_Category_CategoryId",
                table: "HotelCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelCategories_Hotels_HotelId",
                table: "HotelCategories",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelCategories_Category_CategoryId",
                table: "HotelCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelCategories_Hotels_HotelId",
                table: "HotelCategories");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelCategories",
                table: "HotelCategories");

            migrationBuilder.RenameTable(
                name: "HotelCategories",
                newName: "HotelCategory");

            migrationBuilder.RenameIndex(
                name: "IX_HotelCategories_HotelId",
                table: "HotelCategory",
                newName: "IX_HotelCategory_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelCategories_CategoryId",
                table: "HotelCategory",
                newName: "IX_HotelCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelCategory",
                table: "HotelCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelCategory_Category_CategoryId",
                table: "HotelCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelCategory_Hotels_HotelId",
                table: "HotelCategory",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
