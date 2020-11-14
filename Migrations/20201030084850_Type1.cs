using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Migrations
{
    public partial class Type1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Type",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeID",
                table: "User",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Type_TypeID",
                table: "User",
                column: "TypeID",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Type_TypeID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_User_TypeID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "User",
                type: "char(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_Type",
                table: "User",
                column: "Type");
        }
    }
}
