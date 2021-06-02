using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addNumberFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae87810-98c2-4bd2-b5e1-52c6561d6217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eebe4ee-ebde-48a4-9014-43de0bf98b28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb85263f-25e5-4ad9-8c60-2f917bfdadc2", "7db36f03-4bad-4ed0-8cac-38b5e4b27aed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ab21ab1-b1ed-4c76-ba93-66c6e5d43458", "7201f380-fb3f-41bc-919b-d5bd7b3ada5f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9eebe4ee-ebde-48a4-9014-43de0bf98b28", "f171bbf2-18fb-45e4-ae67-b37a4e0b6e4a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae87810-98c2-4bd2-b5e1-52c6561d6217", "eb2bf34f-f34d-4cf6-93b8-acc2926c3660", "Administrator", "ADMINISTRATOR" });
        }
    }
}
