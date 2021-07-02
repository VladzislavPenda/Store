using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class removeColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17e6f23c-52f2-48e4-a0b6-eb8950ae2f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "725a3128-4dd5-482c-9fa6-1f6408e85b68");

            migrationBuilder.RenameColumn(
                name: "mile_age",
                table: "ShopModels",
                newName: "number_of_car");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "330a1167-3661-4192-88ad-6328b6828593", "cbfd5769-32e2-4a65-bf56-c20a46ebd7bb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52acb4c8-c436-4306-8eaa-399d53d59e0a", "d2481f08-6b8b-4a29-bc27-790f60847ddd", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330a1167-3661-4192-88ad-6328b6828593");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52acb4c8-c436-4306-8eaa-399d53d59e0a");

            migrationBuilder.RenameColumn(
                name: "number_of_car",
                table: "ShopModels",
                newName: "mile_age");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "725a3128-4dd5-482c-9fa6-1f6408e85b68", "8c0ccbfd-80b6-49b0-93a2-c31444c87476", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17e6f23c-52f2-48e4-a0b6-eb8950ae2f40", "985912e4-ec73-45cd-867e-71dd54f0868c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
