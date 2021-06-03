using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShop_CarShopGuid",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ff67907-b373-488c-b968-d7cb297d80ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff929890-d621-43dc-ac94-31f84138d150");

            migrationBuilder.RenameColumn(
                name: "CarShopGuid",
                table: "ShopModels",
                newName: "CarShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_CarShopGuid",
                table: "ShopModels",
                newName: "IX_ShopModels_CarShopId");

            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "CarShop",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1752c031-a5b3-43c3-9de4-a56ea4cda185", "98a63e00-cc83-4baf-ba1b-d1738b6ec466", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b34b7a-c407-4a98-a104-b1d69a42f903", "83304f9e-fc5a-439c-a431-929e1928a0c1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShop_CarShopId",
                table: "ShopModels",
                column: "CarShopId",
                principalTable: "CarShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShop_CarShopId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1752c031-a5b3-43c3-9de4-a56ea4cda185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b34b7a-c407-4a98-a104-b1d69a42f903");

            migrationBuilder.RenameColumn(
                name: "CarShopId",
                table: "ShopModels",
                newName: "CarShopGuid");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_CarShopId",
                table: "ShopModels",
                newName: "IX_ShopModels_CarShopGuid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CarShop",
                newName: "Desctiption");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ff67907-b373-488c-b968-d7cb297d80ac", "83e6c12a-8f58-42b5-9800-149dc05158f9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff929890-d621-43dc-ac94-31f84138d150", "c61fe1fc-2f9c-429f-be80-cdc8ad930516", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShop_CarShopGuid",
                table: "ShopModels",
                column: "CarShopGuid",
                principalTable: "CarShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
