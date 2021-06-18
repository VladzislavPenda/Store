using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Storage_storage_id",
                table: "ShopModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Storages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Storages_storage_id",
                table: "ShopModels",
                column: "storage_id",
                principalTable: "Storages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Storages_storage_id",
                table: "ShopModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "Storage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Storage_storage_id",
                table: "ShopModels",
                column: "storage_id",
                principalTable: "Storage",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
