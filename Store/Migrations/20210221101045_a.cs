using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mileage",
                table: "ShopModels",
                newName: "mileAge");

            migrationBuilder.RenameColumn(
                name: "horse_power",
                table: "ShopModels",
                newName: "horsePower");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mileAge",
                table: "ShopModels",
                newName: "mileage");

            migrationBuilder.RenameColumn(
                name: "horsePower",
                table: "ShopModels",
                newName: "horse_power");
        }
    }
}
