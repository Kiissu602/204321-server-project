using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Migrations
{
    public partial class Rule1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAmout",
                table: "Rule");

            migrationBuilder.AddColumn<int>(
                name: "BookAmount",
                table: "Rule",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAmount",
                table: "Rule");

            migrationBuilder.AddColumn<int>(
                name: "BookAmout",
                table: "Rule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
