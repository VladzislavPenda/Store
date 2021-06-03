using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a540a91d-a31f-4393-ac04-98790b76ea9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9c2fbb-a74e-4942-9df1-58ee5ea06816");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ShopModels",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Mark",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "markId",
                table: "Mark",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "markNum",
                table: "Mark",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "EngineType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "engineTypeId",
                table: "EngineType",
                newName: "EngineTypeId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "DriveType",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea7bacd1-0638-44c7-8d32-60c177ce3ccd", "8aab2d6b-0ab2-41e9-a5d8-61c6e951b0f4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80a04aa7-c059-4695-bde8-a4a91635cd28", "e11ce8fd-9478-4f64-90ba-8091dfd5ad4b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80a04aa7-c059-4695-bde8-a4a91635cd28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea7bacd1-0638-44c7-8d32-60c177ce3ccd");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ShopModels",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Mark",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "Mark",
                newName: "markId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Mark",
                newName: "markNum");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "EngineType",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "EngineTypeId",
                table: "EngineType",
                newName: "engineTypeId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DriveType",
                newName: "type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba9c2fbb-a74e-4942-9df1-58ee5ea06816", "4b9fcd08-083b-4e58-ad3b-49a2868dae30", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a540a91d-a31f-4393-ac04-98790b76ea9f", "a29482cd-0a5c-41c4-aa0c-a4fc8237f7de", "Administrator", "ADMINISTRATOR" });
        }
    }
}
