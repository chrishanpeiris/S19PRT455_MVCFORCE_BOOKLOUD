using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLOUD.DataAccessLayer.Migrations
{
    public partial class InitilMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookDetailsDALModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookName = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true),
                    BookEdition = table.Column<string>(nullable: true),
                    BookIsbn = table.Column<string>(nullable: true),
                    UniversityLocation = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    BookImage = table.Column<string>(nullable: true),
                    BookPrice = table.Column<int>(nullable: false),
                    BookDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniversityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    UniversityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitCode = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    UnitDetailsModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Unit_Unit_UnitDetailsModelId",
                        column: x => x.UnitDetailsModelId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_UniversityId",
                table: "Course",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_CourseId",
                table: "Unit",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UnitDetailsModelId",
                table: "Unit",
                column: "UnitDetailsModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDetailsDALModel");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
