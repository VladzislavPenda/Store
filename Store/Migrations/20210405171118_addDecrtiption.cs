using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addDecrtiption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae215378-6f9e-4866-afca-e31a71a43857");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a15acc-bf5c-4a6f-85d8-e46b0b2930c0");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "ShopModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pathToPicture",
                table: "ShopModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23984d14-fda6-41df-8b93-e68b5a887408", "6b17825d-d487-459b-9113-bed44d0af40c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e433f00-56b9-4b32-a58a-7602d683ceb4", "25b1e973-9925-4302-b3a4-2c47273921aa", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23984d14-fda6-41df-8b93-e68b5a887408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e433f00-56b9-4b32-a58a-7602d683ceb4");

            migrationBuilder.DropColumn(
                name: "description",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "pathToPicture",
                table: "ShopModels");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae215378-6f9e-4866-afca-e31a71a43857", "eb23a793-f8fe-4ea7-94e8-d3e2b4a36e79", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4a15acc-bf5c-4a6f-85d8-e46b0b2930c0", "26d17ba0-39aa-4c7f-9601-d60381b05be0", "Administrator", "ADMINISTRATOR" });
        }
    }
}
