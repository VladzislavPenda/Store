using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopTransmissionId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "ShopTransmissionTypeid",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shopTransmissionTypes",
                newName: "transmissionId");

            migrationBuilder.AddColumn<int>(
                name: "transmissionId",
                table: "ShopModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels",
                column: "transmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_transmissionId",
                table: "ShopModels",
                column: "transmissionId",
                principalTable: "shopTransmissionTypes",
                principalColumn: "transmissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_transmissionId",
                table: "ShopModels");

            migrationBuilder.DropIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels");

            migrationBuilder.DropColumn(
                name: "transmissionId",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "transmissionId",
                table: "shopTransmissionTypes",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "ShopTransmissionId",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopTransmissionTypeid",
                table: "ShopModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopTransmissionTypeid",
                table: "ShopModels",
                column: "ShopTransmissionTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_shopTransmissionTypes_ShopTransmissionTypeid",
                table: "ShopModels",
                column: "ShopTransmissionTypeid",
                principalTable: "shopTransmissionTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
