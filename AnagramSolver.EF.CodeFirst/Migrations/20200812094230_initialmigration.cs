using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word1 = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CachedWord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchWord = table.Column<string>(nullable: true),
                    AnagramWordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachedWord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CachedWord_Word_AnagramWordId",
                        column: x => x.AnagramWordId,
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIp = table.Column<string>(nullable: true),
                    SearchWordId = table.Column<int>(nullable: false),
                    SearchTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLog_CachedWord_SearchWordId",
                        column: x => x.SearchWordId,
                        principalTable: "CachedWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CachedWord_AnagramWordId",
                table: "CachedWord",
                column: "AnagramWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_SearchWordId",
                table: "UserLog",
                column: "SearchWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "CachedWord");

            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}
