using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Migrations
{
    public partial class updateModelProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Scanner",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Printer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Book",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Scanner",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Printer",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Book",
                newName: "ID");
        }
    }
}
