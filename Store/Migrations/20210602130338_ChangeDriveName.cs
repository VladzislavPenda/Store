using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ChangeDriveName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropTable(
                name: "shopDriveTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e6c7273-ab59-4fc1-8239-acca638f296c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d301ef-4263-45e7-9e78-49753aa53918");

            migrationBuilder.CreateTable(
                name: "DriveType",
                columns: table => new
                {
                    driveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveType", x => x.driveTypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d21d77f-6fa8-4f36-95ed-6a62ebf966fe", "293cd08b-2d22-45dd-b7cb-394358b67c26", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c89a4135-8407-4eac-8277-976e6f2de284", "51a8693b-345a-40d6-ae13-6d1815a94ee8", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_DriveType_driveTypeId",
                table: "ShopModels",
                column: "driveTypeId",
                principalTable: "DriveType",
                principalColumn: "driveTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_DriveType_driveTypeId",
                table: "ShopModels");

            migrationBuilder.DropTable(
                name: "DriveType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d21d77f-6fa8-4f36-95ed-6a62ebf966fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c89a4135-8407-4eac-8277-976e6f2de284");

            migrationBuilder.CreateTable(
                name: "shopDriveTypes",
                columns: table => new
                {
                    driveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopDriveTypes", x => x.driveTypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3d301ef-4263-45e7-9e78-49753aa53918", "d74b6e98-d844-4571-8742-34a4fc222ac5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e6c7273-ab59-4fc1-8239-acca638f296c", "bfb952c7-bb9d-4863-aa00-9cdf488ad0f1", "Administrator", "ADMINISTRATOR" });

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
