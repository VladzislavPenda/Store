using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CarcaseTypeId",
                table: "CarcaseType",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb9bf63e-dcfc-493b-bf7d-385a6b9a9d21", "37bbab94-8f44-4ad1-bd62-550c7b394756", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "058d39b6-1fc0-4029-b4f7-61027dfcc9a1", "4643f627-27dd-4a43-8d84-c971fc247f37", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058d39b6-1fc0-4029-b4f7-61027dfcc9a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb9bf63e-dcfc-493b-bf7d-385a6b9a9d21");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarcaseType",
                newName: "CarcaseTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea7bacd1-0638-44c7-8d32-60c177ce3ccd", "8aab2d6b-0ab2-41e9-a5d8-61c6e951b0f4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80a04aa7-c059-4695-bde8-a4a91635cd28", "e11ce8fd-9478-4f64-90ba-8091dfd5ad4b", "Administrator", "ADMINISTRATOR" });
        }
    }
}
