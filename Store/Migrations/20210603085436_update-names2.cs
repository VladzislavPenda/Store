using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bf227be-7843-4d93-b79a-bd48e8fa7af1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ca036f-1859-4ba0-b3a3-86008fe14550");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "CarcaseType",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e692c4d-c6eb-41c5-8fd1-38525cc8de20", "2c6d03fd-2bf9-4020-b10a-7a95ba8e26c6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6af8647-499f-419c-9611-1b30fe14dc96", "0eafa921-fef5-4466-8a06-1b7efffae257", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e692c4d-c6eb-41c5-8fd1-38525cc8de20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6af8647-499f-419c-9611-1b30fe14dc96");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CarcaseType",
                newName: "type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bf227be-7843-4d93-b79a-bd48e8fa7af1", "c7c8a18b-28a8-470c-8e93-1eb41761b99d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72ca036f-1859-4ba0-b3a3-86008fe14550", "fba52115-fbb5-4cd2-bffa-f8f416bcbfbe", "Administrator", "ADMINISTRATOR" });
        }
    }
}
