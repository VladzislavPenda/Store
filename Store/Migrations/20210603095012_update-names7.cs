using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058d39b6-1fc0-4029-b4f7-61027dfcc9a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb9bf63e-dcfc-493b-bf7d-385a6b9a9d21");

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "TransmissionType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShopModelId",
                table: "ShopModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "Mark",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EngineTypeId",
                table: "EngineType",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31cf9218-f85e-4d66-92a2-b7b7af65731e", "9b830430-fb51-4d2c-b593-e991b2a7dc24", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "010423b5-dc84-4047-bf65-b9b6ee3c03ac", "6a05bd48-0e9d-47e4-9d3d-26e64b3bd31d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010423b5-dc84-4047-bf65-b9b6ee3c03ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31cf9218-f85e-4d66-92a2-b7b7af65731e");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TransmissionType",
                newName: "TransmissionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShopModels",
                newName: "ShopModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mark",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EngineType",
                newName: "EngineTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb9bf63e-dcfc-493b-bf7d-385a6b9a9d21", "37bbab94-8f44-4ad1-bd62-550c7b394756", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "058d39b6-1fc0-4029-b4f7-61027dfcc9a1", "4643f627-27dd-4a43-8d84-c971fc247f37", "Administrator", "ADMINISTRATOR" });
        }
    }
}
