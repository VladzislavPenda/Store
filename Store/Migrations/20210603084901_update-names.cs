using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarcaseType_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9d1611-de00-4a64-8b98-efe2efaf9ee5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb0ebd35-bbe1-49e9-8b7c-991e0c6f5fae");

            migrationBuilder.RenameColumn(
                name: "carcaseTypeId",
                table: "ShopModels",
                newName: "CarcaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_carcaseTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_CarcaseTypeId");

            migrationBuilder.RenameColumn(
                name: "driveTypeId",
                table: "DriveType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "carcaseTypeId",
                table: "CarcaseType",
                newName: "CarcaseTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bf227be-7843-4d93-b79a-bd48e8fa7af1", "c7c8a18b-28a8-470c-8e93-1eb41761b99d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72ca036f-1859-4ba0-b3a3-86008fe14550", "fba52115-fbb5-4cd2-bffa-f8f416bcbfbe", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarcaseType_CarcaseTypeId",
                table: "ShopModels",
                column: "CarcaseTypeId",
                principalTable: "CarcaseType",
                principalColumn: "CarcaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarcaseType_CarcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bf227be-7843-4d93-b79a-bd48e8fa7af1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ca036f-1859-4ba0-b3a3-86008fe14550");

            migrationBuilder.RenameColumn(
                name: "CarcaseTypeId",
                table: "ShopModels",
                newName: "carcaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_CarcaseTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_carcaseTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DriveType",
                newName: "driveTypeId");

            migrationBuilder.RenameColumn(
                name: "CarcaseTypeId",
                table: "CarcaseType",
                newName: "carcaseTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb9d1611-de00-4a64-8b98-efe2efaf9ee5", "44a32de1-9d0a-4a96-9e54-820f1498223d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb0ebd35-bbe1-49e9-8b7c-991e0c6f5fae", "c5e3a077-78b1-4bde-b570-39b5d6d009e7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarcaseType_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId",
                principalTable: "CarcaseType",
                principalColumn: "carcaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
