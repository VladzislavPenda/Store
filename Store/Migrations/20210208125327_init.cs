using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopCarcaseTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCarcaseTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopDriveTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopDriveTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShopEngineTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopEngineTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopMarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    markNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopMarks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopTransmissionTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopTransmissionTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShopModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    year = table.Column<int>(type: "int", nullable: true),
                    horse_power = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    mileage = table.Column<int>(type: "int", nullable: false),
                    ShopCarcaseTypeid = table.Column<int>(type: "int", nullable: true),
                    ShopEngineTypeid = table.Column<int>(type: "int", nullable: true),
                    ShopTransmissionTypeid = table.Column<int>(type: "int", nullable: true),
                    ShopDriveTypeid = table.Column<int>(type: "int", nullable: true),
                    ShopMarkid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopCarcaseTypes_ShopCarcaseTypeid",
                        column: x => x.ShopCarcaseTypeid,
                        principalTable: "shopCarcaseTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopDriveTypes_ShopDriveTypeid",
                        column: x => x.ShopDriveTypeid,
                        principalTable: "shopDriveTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopModels_ShopEngineTypes_ShopEngineTypeid",
                        column: x => x.ShopEngineTypeid,
                        principalTable: "ShopEngineTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopMarks_ShopMarkid",
                        column: x => x.ShopMarkid,
                        principalTable: "shopMarks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopTransmissionTypes_ShopTransmissionTypeid",
                        column: x => x.ShopTransmissionTypeid,
                        principalTable: "shopTransmissionTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopMarkid",
                table: "ShopModels",
                column: "ShopMarkid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_ShopTransmissionTypeid",
                table: "ShopModels",
                column: "ShopTransmissionTypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopModels");

            migrationBuilder.DropTable(
                name: "shopCarcaseTypes");

            migrationBuilder.DropTable(
                name: "shopDriveTypes");

            migrationBuilder.DropTable(
                name: "ShopEngineTypes");

            migrationBuilder.DropTable(
                name: "shopMarks");

            migrationBuilder.DropTable(
                name: "shopTransmissionTypes");
        }
    }
}
