using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLOUD.Data.Migrations
{
    public partial class UpdateUnitModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Unit_UnitDetailsModelId",
                table: "Unit");

            migrationBuilder.RenameColumn(
                name: "UnitDetailsModelId",
                table: "Unit",
                newName: "UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_UnitDetailsModelId",
                table: "Unit",
                newName: "IX_Unit_UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_University_UniversityId",
                table: "Unit",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_University_UniversityId",
                table: "Unit");

            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Unit",
                newName: "UnitDetailsModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_UniversityId",
                table: "Unit",
                newName: "IX_Unit_UnitDetailsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Unit_UnitDetailsModelId",
                table: "Unit",
                column: "UnitDetailsModelId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
