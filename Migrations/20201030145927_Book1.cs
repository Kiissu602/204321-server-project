using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Migrations
{
    public partial class Book1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookType_BookTypeTypeID",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "BookTypeTypeID",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Book",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(70)");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookType_BookTypeTypeID",
                table: "Book",
                column: "BookTypeTypeID",
                principalTable: "BookType",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookType_BookTypeTypeID",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "BookTypeTypeID",
                table: "Book",
                type: "char(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Book",
                type: "varchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookType_BookTypeTypeID",
                table: "Book",
                column: "BookTypeTypeID",
                principalTable: "BookType",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
