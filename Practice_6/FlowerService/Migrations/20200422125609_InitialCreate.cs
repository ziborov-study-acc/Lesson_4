using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LatinName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantationFlowers",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false),
                    FlowerId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantationFlowers", x => new { x.PlaceId, x.FlowerId });
                    table.ForeignKey(
                        name: "FK_PlantationFlowers_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantationFlowers_Plantations_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Plantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantationId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    SheduledDate = table.Column<DateTime>(nullable: true),
                    ClosedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supply_Plantations_PlantationId",
                        column: x => x.PlantationId,
                        principalTable: "Plantations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseFlowers",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false),
                    FlowerId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseFlowers", x => new { x.PlaceId, x.FlowerId });
                    table.ForeignKey(
                        name: "FK_WarehouseFlowers_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseFlowers_Warehouses_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyFlowers",
                columns: table => new
                {
                    SupplyId = table.Column<int>(nullable: false),
                    FlowerId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyFlowers", x => new { x.SupplyId, x.FlowerId });
                    table.ForeignKey(
                        name: "FK_SupplyFlowers_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyFlowers_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantationFlowers_FlowerId",
                table: "PlantationFlowers",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_PlantationId",
                table: "Supply",
                column: "PlantationId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_WarehouseId",
                table: "Supply",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyFlowers_FlowerId",
                table: "SupplyFlowers",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseFlowers_FlowerId",
                table: "WarehouseFlowers",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantationFlowers");

            migrationBuilder.DropTable(
                name: "SupplyFlowers");

            migrationBuilder.DropTable(
                name: "WarehouseFlowers");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Plantations");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
