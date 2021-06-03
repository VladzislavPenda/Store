using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010423b5-dc84-4047-bf65-b9b6ee3c03ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31cf9218-f85e-4d66-92a2-b7b7af65731e");

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "ShopModels",
                newName: "TransmissionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_TransmissionId",
                table: "ShopModels",
                newName: "IX_ShopModels_TransmissionTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "674e9cf5-82a6-44cf-9586-fdcb8e042884", "7561b922-e463-4134-9e78-efecb1a8c1f5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af7b54e9-b16b-4cff-892c-e136ad5aeadb", "9178e1de-9535-4431-a5e8-14a446406855", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionTypeId",
                table: "ShopModels",
                column: "TransmissionTypeId",
                principalTable: "TransmissionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionTypeId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "674e9cf5-82a6-44cf-9586-fdcb8e042884");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7b54e9-b16b-4cff-892c-e136ad5aeadb");

            migrationBuilder.RenameColumn(
                name: "TransmissionTypeId",
                table: "ShopModels",
                newName: "TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_TransmissionTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_TransmissionId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31cf9218-f85e-4d66-92a2-b7b7af65731e", "9b830430-fb51-4d2c-b593-e991b2a7dc24", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "010423b5-dc84-4047-bf65-b9b6ee3c03ac", "6a05bd48-0e9d-47e4-9d3d-26e64b3bd31d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionId",
                table: "ShopModels",
                column: "TransmissionId",
                principalTable: "TransmissionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
