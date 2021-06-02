using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ChangeCarcaseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20a66e83-8d1d-4630-b7de-528543a34cb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec760113-3501-46a0-804f-bf7cd5840dee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23921de5-ed3c-479c-a10a-0f96f471c4e9", "bdd636f3-541d-4ec4-94f0-1ff1fbba3ab2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b6f12b2-7b85-412f-95cc-cf5ac747c071", "c386f5b6-bca4-4c05-8459-b4aee3328ff8", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23921de5-ed3c-479c-a10a-0f96f471c4e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b6f12b2-7b85-412f-95cc-cf5ac747c071");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec760113-3501-46a0-804f-bf7cd5840dee", "b9dbf373-472a-4a49-a90d-e54b8bdea9dd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20a66e83-8d1d-4630-b7de-528543a34cb4", "6abc69f4-4887-4e1a-aac4-4658aa61d291", "Administrator", "ADMINISTRATOR" });
        }
    }
}
