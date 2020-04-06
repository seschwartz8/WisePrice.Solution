using Microsoft.EntityFrameworkCore.Migrations;

namespace WisePriceApi.Migrations
{
    public partial class AddDealLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                table: "Deals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_UserId1",
                table: "Deals",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_UserId2",
                table: "Deals",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_UserId1",
                table: "Deals",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_UserId2",
                table: "Deals",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_UserId1",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_UserId2",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_UserId1",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_UserId2",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Deals");
        }
    }
}
