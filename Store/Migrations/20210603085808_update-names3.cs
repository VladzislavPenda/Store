using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_TransmissionType_transmissionId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e692c4d-c6eb-41c5-8fd1-38525cc8de20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6af8647-499f-419c-9611-1b30fe14dc96");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "TransmissionType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "transmissionId",
                table: "TransmissionType",
                newName: "TransmissionId");

            migrationBuilder.RenameColumn(
                name: "transmissionId",
                table: "ShopModels",
                newName: "TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels",
                newName: "IX_ShopModels_TransmissionId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62abbbb2-821f-4529-a25a-cb5ee4c2fe1c", "6ceb4932-c33d-407f-87e7-ce5316cd7ef2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06f7411c-ec7d-4e7f-a484-6f86d451a357", "a6d42938-e4b6-4d87-9d7e-a304e4098774", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionId",
                table: "ShopModels",
                column: "TransmissionId",
                principalTable: "TransmissionType",
                principalColumn: "TransmissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_TransmissionType_TransmissionId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06f7411c-ec7d-4e7f-a484-6f86d451a357");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62abbbb2-821f-4529-a25a-cb5ee4c2fe1c");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TransmissionType",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "TransmissionType",
                newName: "transmissionId");

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "ShopModels",
                newName: "transmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_TransmissionId",
                table: "ShopModels",
                newName: "IX_ShopModels_transmissionId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e692c4d-c6eb-41c5-8fd1-38525cc8de20", "2c6d03fd-2bf9-4020-b10a-7a95ba8e26c6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6af8647-499f-419c-9611-1b30fe14dc96", "0eafa921-fef5-4466-8a06-1b7efffae257", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_TransmissionType_transmissionId",
                table: "ShopModels",
                column: "transmissionId",
                principalTable: "TransmissionType",
                principalColumn: "transmissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
