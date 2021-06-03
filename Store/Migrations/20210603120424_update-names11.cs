using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CarShop_CarShopId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profession_ProfessionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_ShopModels_ShopModelId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShop_CarShopId",
                table: "ShopModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profession",
                table: "Profession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarShop",
                table: "CarShop");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1752c031-a5b3-43c3-9de4-a56ea4cda185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b34b7a-c407-4a98-a104-b1d69a42f903");

            migrationBuilder.RenameTable(
                name: "Profession",
                newName: "Professions");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "CarShop",
                newName: "CarShops");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_ShopModelId",
                table: "Pictures",
                newName: "IX_Pictures_ShopModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProfessionId",
                table: "Employees",
                newName: "IX_Employees_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CarShopId",
                table: "Employees",
                newName: "IX_Employees_CarShopId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "ShopModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professions",
                table: "Professions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarShops",
                table: "CarShops",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ShopModels_ShopModelId",
                        column: x => x.ShopModelId,
                        principalTable: "ShopModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd616db7-4a3b-4b4a-b21e-403000561224", "91cf7ae2-fcde-44b6-92ca-0e5d5446af8d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8624e8f7-69f3-474a-93af-115caabe03ff", "574f54ed-dce1-48d7-a335-7a7a7ab91013", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopModelId",
                table: "Orders",
                column: "ShopModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CarShops_CarShopId",
                table: "Employees",
                column: "CarShopId",
                principalTable: "CarShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ShopModels_ShopModelId",
                table: "Pictures",
                column: "ShopModelId",
                principalTable: "ShopModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels",
                column: "CarShopId",
                principalTable: "CarShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CarShops_CarShopId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ShopModels_ShopModelId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopModels_CarShops_CarShopId",
                table: "ShopModels");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professions",
                table: "Professions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarShops",
                table: "CarShops");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8624e8f7-69f3-474a-93af-115caabe03ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd616db7-4a3b-4b4a-b21e-403000561224");

            migrationBuilder.RenameTable(
                name: "Professions",
                newName: "Profession");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "CarShops",
                newName: "CarShop");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_ShopModelId",
                table: "Picture",
                newName: "IX_Picture_ShopModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProfessionId",
                table: "Employee",
                newName: "IX_Employee_ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CarShopId",
                table: "Employee",
                newName: "IX_Employee_CarShopId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "ShopModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profession",
                table: "Profession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarShop",
                table: "CarShop",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1752c031-a5b3-43c3-9de4-a56ea4cda185", "98a63e00-cc83-4baf-ba1b-d1738b6ec466", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b34b7a-c407-4a98-a104-b1d69a42f903", "83304f9e-fc5a-439c-a431-929e1928a0c1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CarShop_CarShopId",
                table: "Employee",
                column: "CarShopId",
                principalTable: "CarShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profession_ProfessionId",
                table: "Employee",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_ShopModels_ShopModelId",
                table: "Picture",
                column: "ShopModelId",
                principalTable: "ShopModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopModels_CarShop_CarShopId",
                table: "ShopModels",
                column: "CarShopId",
                principalTable: "CarShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
