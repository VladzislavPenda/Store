using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab21ab1-b1ed-4c76-ba93-66c6e5d43458");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb85263f-25e5-4ad9-8c60-2f917bfdadc2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec760113-3501-46a0-804f-bf7cd5840dee", "b9dbf373-472a-4a49-a90d-e54b8bdea9dd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20a66e83-8d1d-4630-b7de-528543a34cb4", "6abc69f4-4887-4e1a-aac4-4658aa61d291", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "eb85263f-25e5-4ad9-8c60-2f917bfdadc2", "7db36f03-4bad-4ed0-8cac-38b5e4b27aed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ab21ab1-b1ed-4c76-ba93-66c6e5d43458", "7201f380-fb3f-41bc-919b-d5bd7b3ada5f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
