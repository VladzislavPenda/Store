using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "888ff41f-4517-4e57-aabc-519341beb960", "b740ade2-2867-4c37-9bd4-5cbbbbd35cd3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c313c87-8356-43a6-8624-41e8f5a8388f", "81a254c9-3f0d-48fc-a7cc-377956c1d64f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "888ff41f-4517-4e57-aabc-519341beb960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c313c87-8356-43a6-8624-41e8f5a8388f");
        }
    }
}
