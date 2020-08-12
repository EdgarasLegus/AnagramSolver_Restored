using Microsoft.EntityFrameworkCore.Migrations;

namespace AnagramSolver.EF.CodeFirst.Migrations
{
    public partial class changeUserLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLog_CachedWord_SearchWordId",
                table: "UserLog");

            migrationBuilder.DropIndex(
                name: "IX_UserLog_SearchWordId",
                table: "UserLog");

            migrationBuilder.DropColumn(
                name: "SearchWordId",
                table: "UserLog");

            migrationBuilder.AddColumn<string>(
                name: "SearchWord",
                table: "UserLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchWord",
                table: "UserLog");

            migrationBuilder.AddColumn<int>(
                name: "SearchWordId",
                table: "UserLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_SearchWordId",
                table: "UserLog",
                column: "SearchWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLog_CachedWord_SearchWordId",
                table: "UserLog",
                column: "SearchWordId",
                principalTable: "CachedWord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
