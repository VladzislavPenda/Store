using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updateTableNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Mark_MarkId",
                table: "ShopModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fe43e1-dd6d-4a6a-b0ff-6ce67ab15e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7478b40f-e692-47ac-b047-1c2fe3604629");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "ShopModels",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "NumberOfCar",
                table: "ShopModels",
                newName: "number_of_car");

            migrationBuilder.RenameColumn(
                name: "MileAge",
                table: "ShopModels",
                newName: "mile_age");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "ShopModels",
                newName: "mark_id");

            migrationBuilder.RenameColumn(
                name: "HorsePower",
                table: "ShopModels",
                newName: "horse_power");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShopModels",
                newName: "model_id");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_MarkId",
                table: "ShopModels",
                newName: "IX_ShopModels_mark_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Mark",
                newName: "mark_name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Mark",
                newName: "producing_country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mark",
                newName: "mark_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "EngineType",
                newName: "engine_type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EngineType",
                newName: "engine_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DriveType",
                newName: "drive_type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DriveType",
                newName: "drive_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CarcaseType",
                newName: "carcase_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Mark_mark_id",
                table: "ShopModels",
                column: "mark_id",
                principalTable: "Mark",
                principalColumn: "mark_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_Mark_mark_id",
                table: "ShopModels");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "ShopModels",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "number_of_car",
                table: "ShopModels",
                newName: "NumberOfCar");

            migrationBuilder.RenameColumn(
                name: "mile_age",
                table: "ShopModels",
                newName: "MileAge");

            migrationBuilder.RenameColumn(
                name: "mark_id",
                table: "ShopModels",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "horse_power",
                table: "ShopModels",
                newName: "HorsePower");

            migrationBuilder.RenameColumn(
                name: "model_id",
                table: "ShopModels",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ShopModels_mark_id",
                table: "ShopModels",
                newName: "IX_ShopModels_MarkId");

            migrationBuilder.RenameColumn(
                name: "producing_country",
                table: "Mark",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "mark_name",
                table: "Mark",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "mark_id",
                table: "Mark",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "engine_type",
                table: "EngineType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "engine_id",
                table: "EngineType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "drive_type",
                table: "DriveType",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "drive_id",
                table: "DriveType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "carcase_id",
                table: "CarcaseType",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ShopModels",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37fe43e1-dd6d-4a6a-b0ff-6ce67ab15e94", "6534ff9b-de4e-40bc-ab20-c2db46f0efc3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7478b40f-e692-47ac-b047-1c2fe3604629", "98fa320a-9fa7-4117-9188-6052156f3f63", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_Mark_MarkId",
                table: "ShopModels",
                column: "MarkId",
                principalTable: "Mark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
