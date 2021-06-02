using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8651d378-fcb0-46c8-92d7-81cc15e0d548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc7fbf7-d6e2-4fc0-a825-200e1d915591");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "ShopModels",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eebe4ee-ebde-48a4-9014-43de0bf98b28", "f171bbf2-18fb-45e4-ae67-b37a4e0b6e4a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae87810-98c2-4bd2-b5e1-52c6561d6217", "eb2bf34f-f34d-4cf6-93b8-acc2926c3660", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae87810-98c2-4bd2-b5e1-52c6561d6217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eebe4ee-ebde-48a4-9014-43de0bf98b28");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "ShopModels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8651d378-fcb0-46c8-92d7-81cc15e0d548", "4ff9b435-5a37-4f14-adfd-a8b15b45b08a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acc7fbf7-d6e2-4fc0-a825-200e1d915591", "711fce26-d4de-4009-bd24-59bfad98df7f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
