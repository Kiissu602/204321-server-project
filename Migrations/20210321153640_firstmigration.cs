using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    TypeID = table.Column<string>(type: "char(10)", nullable: false),
                    TypeBook = table.Column<string>(type: "nvarchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Fnum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Fnum);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Type = table.Column<string>(type: "char(10)", nullable: false),
                    BookAmount = table.Column<int>(nullable: false),
                    LimitDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeID);
                    table.UniqueConstraint("AK_Type_TypeName", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "char(10)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Writer = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    YearPublic = table.Column<DateTime>(nullable: false),
                    NumPage = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PrintEdit = table.Column<int>(nullable: false),
                    BookTypeTypeID = table.Column<string>(nullable: true),
                    BookImg = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_BookType_BookTypeTypeID",
                        column: x => x.BookTypeTypeID,
                        principalTable: "BookType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dnum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(nullable: true),
                    FacultyFnum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dnum);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyFnum",
                        column: x => x.FacultyFnum,
                        principalTable: "Faculty",
                        principalColumn: "Fnum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    PID = table.Column<string>(type: "char(10)", nullable: false),
                    Fname = table.Column<string>(nullable: false),
                    Lname = table.Column<string>(nullable: true),
                    TypeID = table.Column<int>(nullable: false),
                    FacultyFnum = table.Column<int>(nullable: false),
                    DepartmentDnum = table.Column<int>(nullable: true),
                    Bdate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(type: "char(10)", nullable: false),
                    Username = table.Column<string>(type: "varchar(16)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Email = table.Column<string>(type: "varchar(896)", nullable: false),
                    ImgUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.PID);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentDnum",
                        column: x => x.DepartmentDnum,
                        principalTable: "Department",
                        principalColumn: "Dnum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Faculty_FacultyFnum",
                        column: x => x.FacultyFnum,
                        principalTable: "Faculty",
                        principalColumn: "Fnum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Type_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    BorrowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPID = table.Column<string>(nullable: false),
                    BookID = table.Column<string>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "char(10)", nullable: false),
                    Fines = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_Borrow_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_User_UserPID",
                        column: x => x.UserPID,
                        principalTable: "User",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookName",
                table: "Book",
                column: "BookName");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookTypeTypeID",
                table: "Book",
                column: "BookTypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Writer",
                table: "Book",
                column: "Writer");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookID",
                table: "Borrow",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_UserPID",
                table: "Borrow",
                column: "UserPID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyFnum",
                table: "Department",
                column: "FacultyFnum");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentDnum",
                table: "User",
                column: "DepartmentDnum");

            migrationBuilder.CreateIndex(
                name: "IX_User_FacultyFnum",
                table: "User",
                column: "FacultyFnum");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeID",
                table: "User",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
