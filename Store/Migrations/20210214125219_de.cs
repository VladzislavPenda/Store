using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class de : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_ShopMarkid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopMarkid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopMarkid",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shopMarks",
                newName: "MarkId");

            migrationBuilder.AddColumn<int>(
                name: "MarkId",
                table: "ShopModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_MarkId",
                table: "ShopModels",
                column: "MarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopMarks_MarkId",
                table: "ShopModels",
                column: "MarkId",
                principalTable: "shopMarks",
                principalColumn: "MarkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_MarkId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_MarkId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "shopMarks",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "ShopMarkid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopMarkid",
                table: "ShopModels",
                column: "ShopMarkid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopMarks_ShopMarkid",
                table: "ShopModels",
                column: "ShopMarkid",
                principalTable: "shopMarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
