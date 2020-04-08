using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WisePriceApi.Migrations
{
    public partial class DatabaseUpdatebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Deals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 1,
                column: "Price",
                value: "$10 for 5 lbs");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 2,
                column: "Price",
                value: "$10");

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 3, 2, 1, 1, "Buy 2lbs get 1lb free", new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName" },
                values: new object[] { 3, "Beef" });

            migrationBuilder.InsertData(
                table: "PinnedDeals",
                columns: new[] { "PinnedDealId", "DealId", "UserId" },
                values: new object[] { 3, 3, 2 });

            migrationBuilder.InsertData(
                table: "PostedDeals",
                columns: new[] { "PostedDealId", "DealId", "UserId" },
                values: new object[] { 3, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PinnedDeals",
                keyColumn: "PinnedDealId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostedDeals",
                keyColumn: "PostedDealId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Deals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 1,
                column: "Price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 2,
                column: "Price",
                value: 10);
        }
    }
}
