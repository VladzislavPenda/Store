using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3032b988-43ec-4929-955e-f2166de93be3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb231f8-32db-42f9-929d-5d04f50c84eb");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "shopDriveTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e00e936b-bf52-420b-bbb0-c523a53b31ae", "80040569-e0d7-4bab-8260-f77b08fc83ef", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c87dd22-afe0-4c25-975a-49a18afc5cfd", "d818d5cb-163a-4e03-bea4-f6dc101a8cbc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c87dd22-afe0-4c25-975a-49a18afc5cfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e00e936b-bf52-420b-bbb0-c523a53b31ae");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "shopDriveTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb231f8-32db-42f9-929d-5d04f50c84eb", "a52caae8-fb2c-4807-99e9-d0305b15b734", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3032b988-43ec-4929-955e-f2166de93be3", "41dec009-6060-4ae9-8ef4-50daff0257ca", "Administrator", "ADMINISTRATOR" });
        }
    }
}
