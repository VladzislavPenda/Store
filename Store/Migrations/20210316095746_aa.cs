using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_driveTypeId",
                table: "ShopModels");

            migrationBuilder.AddColumn<int>(
                name: "ShopDriveTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopDriveTypeid",
                table: "ShopModels",
                column: "ShopDriveTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopDriveTypes_ShopDriveTypeid",
                table: "ShopModels",
                column: "ShopDriveTypeid",
                principalTable: "shopDriveTypes",
                principalColumn: "driveTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopDriveTypes_ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId",
                principalTable: "shopDriveTypes",
                principalColumn: "driveTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
