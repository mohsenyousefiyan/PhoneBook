using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Infra.DAL.SQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    State = table.Column<byte>(type: "TinyInt", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<byte>(type: "TinyInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ContactPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberType = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ContactPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactPhoneNumbers_Tbl_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Tbl_Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ContactGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ContactGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactGroups_Tbl_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Tbl_Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_ContactGroups_Tbl_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Tbl_Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Tbl_Groups",
                columns: new[] { "Id", "GroupName", "State" },
                values: new object[] { 1, "Group01", (byte)1 });

            migrationBuilder.InsertData(
                table: "Tbl_Groups",
                columns: new[] { "Id", "GroupName", "State" },
                values: new object[] { 2, "Group02", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactGroups_ContactId",
                table: "Tbl_ContactGroups",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactGroups_GroupId",
                table: "Tbl_ContactGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ContactPhoneNumbers_ContactId",
                table: "Tbl_ContactPhoneNumbers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupName",
                table: "Tbl_Groups",
                column: "GroupName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ContactGroups");

            migrationBuilder.DropTable(
                name: "Tbl_ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Tbl_Groups");

            migrationBuilder.DropTable(
                name: "Tbl_Contacts");
        }
    }
}
