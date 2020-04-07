using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WisePriceApi.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName" },
                values: new object[,]
                {
                    { 1, "Strawberry" },
                    { 2, "Milk" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "Name", "ZipCode" },
                values: new object[,]
                {
                    { 1, "300 Bellevue Way NE", "SafeWay", 98015 },
                    { 2, "2636 Bellevue Way NE", "QFC", 98004 },
                    { 3, "1212 Bellevue Way NE", "QFC", 98004 },
                    { 4, "1212 Seattle Way NE", "SafeWay", 98015 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                column: "UserId",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 1, 2, 1, 1, 20, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 2, 1, 2, 2, 10, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 });

            migrationBuilder.InsertData(
                table: "PinnedDeals",
                columns: new[] { "PinnedDealId", "DealId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PostedDeals",
                columns: new[] { "PostedDealId", "DealId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PinnedDeals",
                keyColumn: "PinnedDealId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PinnedDeals",
                keyColumn: "PinnedDealId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostedDeals",
                keyColumn: "PostedDealId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostedDeals",
                keyColumn: "PostedDealId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "DealId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
