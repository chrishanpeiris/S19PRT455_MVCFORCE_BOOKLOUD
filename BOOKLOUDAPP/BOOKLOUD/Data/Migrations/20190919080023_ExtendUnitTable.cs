using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLOUD.Data.Migrations
{
    public partial class ExtendUnitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitCode",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitDetailsModelId",
                table: "Unit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UnitDetailsModelId",
                table: "Unit",
                column: "UnitDetailsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Unit_UnitDetailsModelId",
                table: "Unit",
                column: "UnitDetailsModelId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Unit_UnitDetailsModelId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_UnitDetailsModelId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UnitCode",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UnitDetailsModelId",
                table: "Unit");
        }
    }
}
