using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class tr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopDriveTypes_ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_MarkId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopDriveTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "ShopModels",
                newName: "markId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_MarkId",
                table: "ShopModels",
                newName: "IX_ShopModels_markId");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "shopMarks",
                newName: "markId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ShopEngineTypes",
                newName: "engineTypeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shopDriveTypes",
                newName: "driveTypeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shopCarcaseTypes",
                newName: "carcaseTypeId");

            migrationBuilder.AddColumn<int>(
                name: "carcaseTypeId",
                table: "ShopModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "driveTypeId",
                table: "ShopModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "engineTypeId",
                table: "ShopModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_engineTypeId",
                table: "ShopModels",
                column: "engineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId",
                principalTable: "shopCarcaseTypes",
                principalColumn: "carcaseTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId",
                principalTable: "shopDriveTypes",
                principalColumn: "driveTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_engineTypeId",
                table: "ShopModels",
                column: "engineTypeId",
                principalTable: "ShopEngineTypes",
                principalColumn: "engineTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopMarks_markId",
                table: "ShopModels",
                column: "markId",
                principalTable: "shopMarks",
                principalColumn: "markId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_engineTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_markId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_engineTypeId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "engineTypeId",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "markId",
                table: "ShopModels",
                newName: "MarkId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_markId",
                table: "ShopModels",
                newName: "IX_ShopModels_MarkId");

            migrationBuilder.RenameColumn(
                name: "markId",
                table: "shopMarks",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "engineTypeId",
                table: "ShopEngineTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "driveTypeId",
                table: "shopDriveTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "carcaseTypeId",
                table: "shopCarcaseTypes",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "ShopCarcaseTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopDriveTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopEngineTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopCarcaseTypeid",
                table: "ShopModels",
                column: "ShopCarcaseTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopDriveTypeid",
                table: "ShopModels",
                column: "ShopDriveTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopEngineTypeid",
                table: "ShopModels",
                column: "ShopEngineTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_ShopCarcaseTypeid",
                table: "ShopModels",
                column: "ShopCarcaseTypeid",
                principalTable: "shopCarcaseTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopDriveTypes_ShopDriveTypeid",
                table: "ShopModels",
                column: "ShopDriveTypeid",
                principalTable: "shopDriveTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_ShopEngineTypeid",
                table: "ShopModels",
                column: "ShopEngineTypeid",
                principalTable: "ShopEngineTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopMarks_MarkId",
                table: "ShopModels",
                column: "MarkId",
                principalTable: "shopMarks",
                principalColumn: "MarkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
