using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class delet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopTransmissionId",
                table: "ShopModels",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopTransmissionId",
                table: "ShopModels");
        }
    }
}
