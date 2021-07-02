using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c95d302-e763-4791-91a7-4a7c962e23ff", "b4f17021-2652-4634-8eee-689ec9a03cf6", "User", "USER" },
                    { "2e56e316-67dd-4414-afd3-5881c7c73958", "fb35d227-dbf1-4c74-b9a7-daab3c23700c", "Administrator", "ADMINISTRATOR" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e56e316-67dd-4414-afd3-5881c7c73958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c95d302-e763-4791-91a7-4a7c962e23ff"); 
        }
    }
}
