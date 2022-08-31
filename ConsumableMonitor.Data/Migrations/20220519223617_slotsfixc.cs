using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableMonitor.Data.Migrations
{
    public partial class slotsfixc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_EquipmentSlots_InstalledInEquipmentId_Installed~",
                table: "Consumables");

            migrationBuilder.DropColumn(
                name: "InstalledId",
                table: "EquipmentSlots");

            migrationBuilder.AlterColumn<int>(
                name: "InstalledInNumber",
                table: "Consumables",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InstalledInEquipmentId",
                table: "Consumables",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_EquipmentSlots_InstalledInEquipmentId_Installed~",
                table: "Consumables",
                columns: new[] { "InstalledInEquipmentId", "InstalledInNumber" },
                principalTable: "EquipmentSlots",
                principalColumns: new[] { "EquipmentId", "SlotNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_EquipmentSlots_InstalledInEquipmentId_Installed~",
                table: "Consumables");

            migrationBuilder.AddColumn<int>(
                name: "InstalledId",
                table: "EquipmentSlots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InstalledInNumber",
                table: "Consumables",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstalledInEquipmentId",
                table: "Consumables",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_EquipmentSlots_InstalledInEquipmentId_Installed~",
                table: "Consumables",
                columns: new[] { "InstalledInEquipmentId", "InstalledInNumber" },
                principalTable: "EquipmentSlots",
                principalColumns: new[] { "EquipmentId", "SlotNumber" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
