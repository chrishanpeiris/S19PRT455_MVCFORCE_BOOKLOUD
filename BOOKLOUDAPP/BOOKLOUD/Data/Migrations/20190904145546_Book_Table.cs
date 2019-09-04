using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BOOKLOUD.Data.Migrations
{
    public partial class Book_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
