using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_engineTypeId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_markId",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_transmissionId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_carcaseTypeId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_engineTypeId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_markId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels");

            migrationBuilder.AddColumn<int>(
                name: "ShopCarcaseTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopEngineTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopMarkid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopTransmissionTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopCarcaseTypeid",
                table: "ShopModels",
                column: "ShopCarcaseTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopEngineTypeid",
                table: "ShopModels",
                column: "ShopEngineTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopMarkid",
                table: "ShopModels",
                column: "ShopMarkid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopTransmissionTypeid",
                table: "ShopModels",
                column: "ShopTransmissionTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_ShopCarcaseTypeid",
                table: "ShopModels",
                column: "ShopCarcaseTypeid",
                principalTable: "shopCarcaseTypes",
                principalColumn: "carcaseTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_ShopEngineTypeid",
                table: "ShopModels",
                column: "ShopEngineTypeid",
                principalTable: "ShopEngineTypes",
                principalColumn: "engineTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopMarks_ShopMarkid",
                table: "ShopModels",
                column: "ShopMarkid",
                principalTable: "shopMarks",
                principalColumn: "markId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_ShopTransmissionTypeid",
                table: "ShopModels",
                column: "ShopTransmissionTypeid",
                principalTable: "shopTransmissionTypes",
                principalColumn: "transmissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_ShopEngineTypes_ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopMarks_ShopMarkid",
                table: "ShopModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopMarkid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopCarcaseTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopEngineTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopMarkid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_engineTypeId",
                table: "ShopModels",
                column: "engineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_markId",
                table: "ShopModels",
                column: "markId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels",
                column: "transmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                table: "ShopModels",
                column: "carcaseTypeId",
                principalTable: "shopCarcaseTypes",
                principalColumn: "carcaseTypeId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_transmissionId",
                table: "ShopModels",
                column: "transmissionId",
                principalTable: "shopTransmissionTypes",
                principalColumn: "transmissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
