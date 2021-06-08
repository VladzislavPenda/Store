using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595e2abf-476e-4a47-a72e-58296ee76ae5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a8f77a-4346-4e04-94f0-e806cd5e44e3");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarcaseType",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CarcaseType",
                newName: "carcase_type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37fe43e1-dd6d-4a6a-b0ff-6ce67ab15e94", "6534ff9b-de4e-40bc-ab20-c2db46f0efc3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7478b40f-e692-47ac-b047-1c2fe3604629", "98fa320a-9fa7-4117-9188-6052156f3f63", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fe43e1-dd6d-4a6a-b0ff-6ce67ab15e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7478b40f-e692-47ac-b047-1c2fe3604629");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CarcaseType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "carcase_type",
                table: "CarcaseType",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "595e2abf-476e-4a47-a72e-58296ee76ae5", "70f6f154-0583-43ad-b938-d776c85b2d9a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5a8f77a-4346-4e04-94f0-e806cd5e44e3", "cef7db7b-6429-4f97-86ba-fb093018d6ba", "Administrator", "ADMINISTRATOR" });
        }
    }
}
