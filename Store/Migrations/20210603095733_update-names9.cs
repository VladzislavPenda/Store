using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class updatenames9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CarShop_CarShopId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profession_ProfessionGuid",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "674e9cf5-82a6-44cf-9586-fdcb8e042884");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7b54e9-b16b-4cff-892c-e136ad5aeadb");

            migrationBuilder.DropColumn(
                name: "CarShopGuid",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "Profession",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeGuid",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfessionGuid",
                table: "Employee",
                newName: "ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProfessionGuid",
                table: "Employee",
                newName: "IX_Employee_ProfessionId");

            migrationBuilder.RenameColumn(
                name: "CarShopGuid",
                table: "CarShop",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ff67907-b373-488c-b968-d7cb297d80ac", "83e6c12a-8f58-42b5-9800-149dc05158f9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff929890-d621-43dc-ac94-31f84138d150", "c61fe1fc-2f9c-429f-be80-cdc8ad930516", "Administrator", "ADMINISTRATOR" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CarShop_CarShopId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Profession_ProfessionId",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ff67907-b373-488c-b968-d7cb297d80ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff929890-d621-43dc-ac94-31f84138d150");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profession",
                newName: "ProfessionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "EmployeeGuid");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "Employee",
                newName: "ProfessionGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProfessionId",
                table: "Employee",
                newName: "IX_Employee_ProfessionGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarShop",
                newName: "CarShopGuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarShopId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CarShopGuid",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "674e9cf5-82a6-44cf-9586-fdcb8e042884", "7561b922-e463-4134-9e78-efecb1a8c1f5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af7b54e9-b16b-4cff-892c-e136ad5aeadb", "9178e1de-9535-4431-a5e8-14a446406855", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CarShop_CarShopId",
                table: "Employee",
                column: "CarShopId",
                principalTable: "CarShop",
                principalColumn: "CarShopGuid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Profession_ProfessionGuid",
                table: "Employee",
                column: "ProfessionGuid",
                principalTable: "Profession",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
