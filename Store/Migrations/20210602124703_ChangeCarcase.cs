using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ChangeCarcase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopCarcaseTypes",
                table: "shopCarcaseTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23921de5-ed3c-479c-a10a-0f96f471c4e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b6f12b2-7b85-412f-95cc-cf5ac747c071");

            migrationBuilder.RenameTable(
                name: "shopCarcaseTypes",
                newName: "CarcaseType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarcaseType",
                table: "CarcaseType",
                column: "carcaseTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3d301ef-4263-45e7-9e78-49753aa53918", "d74b6e98-d844-4571-8742-34a4fc222ac5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e6c7273-ab59-4fc1-8239-acca638f296c", "bfb952c7-bb9d-4863-aa00-9cdf488ad0f1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarcaseType_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId",
                principalTable: "CarcaseType",
                principalColumn: "carcaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarcaseType_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarcaseType",
                table: "CarcaseType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e6c7273-ab59-4fc1-8239-acca638f296c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d301ef-4263-45e7-9e78-49753aa53918");

            migrationBuilder.RenameTable(
                name: "CarcaseType",
                newName: "shopCarcaseTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopCarcaseTypes",
                table: "shopCarcaseTypes",
                column: "carcaseTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23921de5-ed3c-479c-a10a-0f96f471c4e9", "bdd636f3-541d-4ec4-94f0-1ff1fbba3ab2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b6f12b2-7b85-412f-95cc-cf5ac747c071", "c386f5b6-bca4-4c05-8459-b4aee3328ff8", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId",
                principalTable: "shopCarcaseTypes",
                principalColumn: "carcaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
