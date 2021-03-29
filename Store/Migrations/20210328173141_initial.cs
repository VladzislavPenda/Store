using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopCarcaseTypes",
                columns: table => new
                {
                    carcaseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCarcaseTypes", x => x.carcaseTypeId);
                });

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

            migrationBuilder.CreateTable(
                name: "ShopEngineTypes",
                columns: table => new
                {
                    engineTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopEngineTypes", x => x.engineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "shopMarks",
                columns: table => new
                {
                    markId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    markNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopMarks", x => x.markId);
                });

            migrationBuilder.CreateTable(
                name: "shopTransmissionTypes",
                columns: table => new
                {
                    transmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopTransmissionTypes", x => x.transmissionId);
                });

            migrationBuilder.CreateTable(
                name: "ShopModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    year = table.Column<int>(type: "int", nullable: true),
                    horsePower = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    mileAge = table.Column<int>(type: "int", nullable: false),
                    markId = table.Column<int>(type: "int", nullable: false),
                    transmissionId = table.Column<int>(type: "int", nullable: false),
                    carcaseTypeId = table.Column<int>(type: "int", nullable: false),
                    engineTypeId = table.Column<int>(type: "int", nullable: false),
                    driveTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopCarcaseTypes_carcaseTypeId",
                        column: x => x.carcaseTypeId,
                        principalTable: "shopCarcaseTypes",
                        principalColumn: "carcaseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopDriveTypes_driveTypeId",
                        column: x => x.driveTypeId,
                        principalTable: "shopDriveTypes",
                        principalColumn: "driveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopModels_ShopEngineTypes_engineTypeId",
                        column: x => x.engineTypeId,
                        principalTable: "ShopEngineTypes",
                        principalColumn: "engineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopMarks_markId",
                        column: x => x.markId,
                        principalTable: "shopMarks",
                        principalColumn: "markId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopModels_shopTransmissionTypes_transmissionId",
                        column: x => x.transmissionId,
                        principalTable: "shopTransmissionTypes",
                        principalColumn: "transmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_markId",
                table: "ShopModels",
                column: "markId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopModels_transmissionId",
                table: "ShopModels",
                column: "transmissionId");
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
