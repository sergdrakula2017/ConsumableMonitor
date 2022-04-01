using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableMonitor.Data.Migrations
{
    public partial class MoneyInInventoryDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Equipments",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Consumables",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Consumables");
        }
    }
}
