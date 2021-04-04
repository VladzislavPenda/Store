using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "888ff41f-4517-4e57-aabc-519341beb960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c313c87-8356-43a6-8624-41e8f5a8388f");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "ShopModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pathToPicture",
                table: "ShopModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb231f8-32db-42f9-929d-5d04f50c84eb", "a52caae8-fb2c-4807-99e9-d0305b15b734", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3032b988-43ec-4929-955e-f2166de93be3", "41dec009-6060-4ae9-8ef4-50daff0257ca", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3032b988-43ec-4929-955e-f2166de93be3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb231f8-32db-42f9-929d-5d04f50c84eb");

            migrationBuilder.DropColumn(
                name: "description",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "pathToPicture",
                table: "ShopModels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "888ff41f-4517-4e57-aabc-519341beb960", "b740ade2-2867-4c37-9bd4-5cbbbbd35cd3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c313c87-8356-43a6-8624-41e8f5a8388f", "81a254c9-3f0d-48fc-a7cc-377956c1d64f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
