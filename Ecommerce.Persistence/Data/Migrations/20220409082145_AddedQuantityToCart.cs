using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persistence.Data.Migrations
{
    public partial class AddedQuantityToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderProducts",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartProducts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderProducts",
                newName: "quantity");
        }
    }
}
