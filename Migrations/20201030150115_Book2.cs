using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Migrations
{
    public partial class Book2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Writer",
                table: "Book",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(70)");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Book",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Writer",
                table: "Book",
                type: "varchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Book",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }
    }
}
