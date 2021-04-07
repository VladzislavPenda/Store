using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class init : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae215378-6f9e-4866-afca-e31a71a43857", "eb23a793-f8fe-4ea7-94e8-d3e2b4a36e79", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4a15acc-bf5c-4a6f-85d8-e46b0b2930c0", "26d17ba0-39aa-4c7f-9601-d60381b05be0", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae215378-6f9e-4866-afca-e31a71a43857");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a15acc-bf5c-4a6f-85d8-e46b0b2930c0");

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
