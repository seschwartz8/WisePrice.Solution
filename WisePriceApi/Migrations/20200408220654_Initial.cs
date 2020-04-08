using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WisePriceApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    DealId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    TimeUpdated = table.Column<DateTime>(nullable: false),
                    UpVotes = table.Column<int>(nullable: false),
                    DownVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.DealId);
                    table.ForeignKey(
                        name: "FK_Deals_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PinnedDeals",
                columns: table => new
                {
                    PinnedDealId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    DealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinnedDeals", x => x.PinnedDealId);
                    table.ForeignKey(
                        name: "FK_PinnedDeals_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "DealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PinnedDeals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostedDeals",
                columns: table => new
                {
                    PostedDealId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    DealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostedDeals", x => x.PostedDealId);
                    table.ForeignKey(
                        name: "FK_PostedDeals_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "DealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostedDeals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName" },
                values: new object[,]
                {
                    { 1, "Strawberry" },
                    { 2, "Milk" },
                    { 3, "Beef" }
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
                    "145c9f41-ed89-43c7-8619-e13188de7188",
                    "test"
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 1, 2, 1, 1, "$10 for 5 lbs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "145c9f41-ed89-43c7-8619-e13188de7188" });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 3, 2, 1, 1, "Buy 2lbs get 1lb free", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "145c9f41-ed89-43c7-8619-e13188de7188" });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "DealId", "DownVotes", "ItemId", "LocationId", "Price", "TimeUpdated", "UpVotes", "UserId" },
                values: new object[] { 2, 1, 2, 2, "$10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "test" });

            migrationBuilder.InsertData(
                table: "PinnedDeals",
                columns: new[] { "PinnedDealId", "DealId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "145c9f41-ed89-43c7-8619-e13188de7188" },
                    { 3, 3, "test" },
                    { 2, 2, "test" }
                });

            migrationBuilder.InsertData(
                table: "PostedDeals",
                columns: new[] { "PostedDealId", "DealId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "145c9f41-ed89-43c7-8619-e13188de7188" },
                    { 3, 3, "test" },
                    { 2, 2, "test" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ItemId",
                table: "Deals",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_LocationId",
                table: "Deals",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_UserId",
                table: "Deals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PinnedDeals_DealId",
                table: "PinnedDeals",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_PinnedDeals_UserId",
                table: "PinnedDeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostedDeals_DealId",
                table: "PostedDeals",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_PostedDeals_UserId",
                table: "PostedDeals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinnedDeals");

            migrationBuilder.DropTable(
                name: "PostedDeals");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
