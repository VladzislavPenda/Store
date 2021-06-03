using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_DriveType_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_EngineType_engineTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Mark_markId",
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
                name: "year",
                table: "ShopModels",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "ShopModels",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "ShopModels",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "ShopModels",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "mileAge",
                table: "ShopModels",
                newName: "MileAge");

            migrationBuilder.RenameColumn(
                name: "markId",
                table: "ShopModels",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "horsePower",
                table: "ShopModels",
                newName: "HorsePower");

            migrationBuilder.RenameColumn(
                name: "engineTypeId",
                table: "ShopModels",
                newName: "EngineTypeId");

            migrationBuilder.RenameColumn(
                name: "driveTypeId",
                table: "ShopModels",
                newName: "DriveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_markId",
                table: "ShopModels",
                newName: "IX_ShopModels_MarkId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_engineTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_EngineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_driveTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_DriveTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba9c2fbb-a74e-4942-9df1-58ee5ea06816", "4b9fcd08-083b-4e58-ad3b-49a2868dae30", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a540a91d-a31f-4393-ac04-98790b76ea9f", "a29482cd-0a5c-41c4-aa0c-a4fc8237f7de", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_DriveType_DriveTypeId",
                table: "ShopModels",
                column: "DriveTypeId",
                principalTable: "DriveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_EngineType_EngineTypeId",
                table: "ShopModels",
                column: "EngineTypeId",
                principalTable: "EngineType",
                principalColumn: "engineTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Mark_MarkId",
                table: "ShopModels",
                column: "MarkId",
                principalTable: "Mark",
                principalColumn: "markId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_DriveType_DriveTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_EngineType_EngineTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Mark_MarkId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a540a91d-a31f-4393-ac04-98790b76ea9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9c2fbb-a74e-4942-9df1-58ee5ea06816");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "ShopModels",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShopModels",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ShopModels",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "ShopModels",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "MileAge",
                table: "ShopModels",
                newName: "mileAge");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "ShopModels",
                newName: "markId");

            migrationBuilder.RenameColumn(
                name: "HorsePower",
                table: "ShopModels",
                newName: "horsePower");

            migrationBuilder.RenameColumn(
                name: "EngineTypeId",
                table: "ShopModels",
                newName: "engineTypeId");

            migrationBuilder.RenameColumn(
                name: "DriveTypeId",
                table: "ShopModels",
                newName: "driveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_MarkId",
                table: "ShopModels",
                newName: "IX_ShopModels_markId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_EngineTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_engineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_DriveTypeId",
                table: "ShopModels",
                newName: "IX_ShopModels_driveTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62abbbb2-821f-4529-a25a-cb5ee4c2fe1c", "6ceb4932-c33d-407f-87e7-ce5316cd7ef2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06f7411c-ec7d-4e7f-a484-6f86d451a357", "a6d42938-e4b6-4d87-9d7e-a304e4098774", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_DriveType_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId",
                principalTable: "DriveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_EngineType_engineTypeId",
                table: "ShopModels",
                column: "engineTypeId",
                principalTable: "EngineType",
                principalColumn: "engineTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Mark_markId",
                table: "ShopModels",
                column: "markId",
                principalTable: "Mark",
                principalColumn: "markId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
