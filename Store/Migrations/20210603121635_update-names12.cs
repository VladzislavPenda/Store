using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8624e8f7-69f3-474a-93af-115caabe03ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd616db7-4a3b-4b4a-b21e-403000561224");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "ShopModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "595e2abf-476e-4a47-a72e-58296ee76ae5", "70f6f154-0583-43ad-b938-d776c85b2d9a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5a8f77a-4346-4e04-94f0-e806cd5e44e3", "cef7db7b-6429-4f97-86ba-fb093018d6ba", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels",
                column: "CarShopId",
                principalTable: "CarShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595e2abf-476e-4a47-a72e-58296ee76ae5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a8f77a-4346-4e04-94f0-e806cd5e44e3");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "ShopModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd616db7-4a3b-4b4a-b21e-403000561224", "91cf7ae2-fcde-44b6-92ca-0e5d5446af8d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8624e8f7-69f3-474a-93af-115caabe03ff", "574f54ed-dce1-48d7-a335-7a7a7ab91013", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels",
                column: "CarShopId",
                principalTable: "CarShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
