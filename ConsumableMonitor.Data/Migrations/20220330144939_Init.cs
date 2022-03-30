using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsumableMonitor.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumableModelsFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableModelsFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModels", x => x.Id);
                    table.UniqueConstraint("AK_EquipmentModels_Producer_Model", x => new { x.Producer, x.Model });
                });

            migrationBuilder.CreateTable(
                name: "ConsumableModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    FamilyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableModels", x => x.Id);
                    table.UniqueConstraint("AK_ConsumableModels_Producer_Model", x => new { x.Producer, x.Model });
                    table.ForeignKey(
                        name: "FK_ConsumableModels_ConsumableModelsFamilies_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "ConsumableModelsFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Scrapped = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "EquipmentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentSlotDescriptors",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    SlotNumber = table.Column<int>(type: "integer", nullable: false),
                    ConsumableModelFamilyId = table.Column<int>(type: "integer", nullable: false),
                    ConsumableModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentSlotDescriptors", x => new { x.ModelId, x.SlotNumber });
                    table.ForeignKey(
                        name: "FK_EquipmentSlotDescriptors_ConsumableModels_ConsumableModelId",
                        column: x => x.ConsumableModelId,
                        principalTable: "ConsumableModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentSlotDescriptors_ConsumableModelsFamilies_Consumabl~",
                        column: x => x.ConsumableModelFamilyId,
                        principalTable: "ConsumableModelsFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentSlotDescriptors_EquipmentModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "EquipmentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentSlots",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false),
                    SlotNumber = table.Column<int>(type: "integer", nullable: false),
                    InstalledId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentSlots", x => new { x.EquipmentId, x.SlotNumber });
                    table.ForeignKey(
                        name: "FK_EquipmentSlots_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Scrapped = table.Column<bool>(type: "boolean", nullable: false),
                    InstalledInEquipmentId = table.Column<int>(type: "integer", nullable: false),
                    InstalledInNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumables_ConsumableModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ConsumableModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumables_EquipmentSlots_InstalledInEquipmentId_Installed~",
                        columns: x => new { x.InstalledInEquipmentId, x.InstalledInNumber },
                        principalTable: "EquipmentSlots",
                        principalColumns: new[] { "EquipmentId", "SlotNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableModels_FamilyId",
                table: "ConsumableModels",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableModels_Model",
                table: "ConsumableModels",
                column: "Model");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableModels_Producer",
                table: "ConsumableModels",
                column: "Producer");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_InstalledInEquipmentId_InstalledInNumber",
                table: "Consumables",
                columns: new[] { "InstalledInEquipmentId", "InstalledInNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ModelId",
                table: "Consumables",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_SerialNumber",
                table: "Consumables",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModels_Model",
                table: "EquipmentModels",
                column: "Model");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModels_Producer",
                table: "EquipmentModels",
                column: "Producer");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ModelId",
                table: "Equipments",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SerialNumber",
                table: "Equipments",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlotDescriptors_ConsumableModelFamilyId",
                table: "EquipmentSlotDescriptors",
                column: "ConsumableModelFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlotDescriptors_ConsumableModelId",
                table: "EquipmentSlotDescriptors",
                column: "ConsumableModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlotDescriptors_ModelId",
                table: "EquipmentSlotDescriptors",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlots_EquipmentId",
                table: "EquipmentSlots",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "EquipmentSlotDescriptors");

            migrationBuilder.DropTable(
                name: "EquipmentSlots");

            migrationBuilder.DropTable(
                name: "ConsumableModels");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "ConsumableModelsFamilies");

            migrationBuilder.DropTable(
                name: "EquipmentModels");
        }
    }
}
