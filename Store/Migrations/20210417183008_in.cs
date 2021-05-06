using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23984d14-fda6-41df-8b93-e68b5a887408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e433f00-56b9-4b32-a58a-7602d683ceb4");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "shopCarcaseTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8651d378-fcb0-46c8-92d7-81cc15e0d548", "4ff9b435-5a37-4f14-adfd-a8b15b45b08a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acc7fbf7-d6e2-4fc0-a825-200e1d915591", "711fce26-d4de-4009-bd24-59bfad98df7f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8651d378-fcb0-46c8-92d7-81cc15e0d548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc7fbf7-d6e2-4fc0-a825-200e1d915591");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "shopCarcaseTypes",
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
                values: new object[] { "23984d14-fda6-41df-8b93-e68b5a887408", "6b17825d-d487-459b-9113-bed44d0af40c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e433f00-56b9-4b32-a58a-7602d683ceb4", "25b1e973-9925-4302-b3a4-2c47273921aa", "Administrator", "ADMINISTRATOR" });
        }
    }
}
