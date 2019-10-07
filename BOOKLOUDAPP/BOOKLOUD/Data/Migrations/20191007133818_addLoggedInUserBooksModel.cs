using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLOUD.Data.Migrations
{
    public partial class addLoggedInUserBooksModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_University_UniversityId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Book",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookAuthor",
                table: "Book",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Book",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_University_UniversityId",
                table: "Course",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_University_UniversityId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Course",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "BookAuthor",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_University_UniversityId",
                table: "Course",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
