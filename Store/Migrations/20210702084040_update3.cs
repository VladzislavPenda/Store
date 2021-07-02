using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e56e316-67dd-4414-afd3-5881c7c73958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d3be244-52ff-4be6-94c9-21886aef3d26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c95d302-e763-4791-91a7-4a7c962e23ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a833beae-d9d6-44c8-bc6b-e0a878698ad3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "725a3128-4dd5-482c-9fa6-1f6408e85b68", "8c0ccbfd-80b6-49b0-93a2-c31444c87476", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17e6f23c-52f2-48e4-a0b6-eb8950ae2f40", "985912e4-ec73-45cd-867e-71dd54f0868c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17e6f23c-52f2-48e4-a0b6-eb8950ae2f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "725a3128-4dd5-482c-9fa6-1f6408e85b68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c95d302-e763-4791-91a7-4a7c962e23ff", "b4f17021-2652-4634-8eee-689ec9a03cf6", "User", "USER" },
                    { "2e56e316-67dd-4414-afd3-5881c7c73958", "fb35d227-dbf1-4c74-b9a7-daab3c23700c", "Administrator", "ADMINISTRATOR" },
                    { "6d3be244-52ff-4be6-94c9-21886aef3d26", "27719a6e-a734-4b56-92cc-2e1b94567e2c", "User", "USER" },
                    { "a833beae-d9d6-44c8-bc6b-e0a878698ad3", "edf6f263-0d9e-4703-810f-8e5d8a7ec0c7", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
