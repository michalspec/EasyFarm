using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFarm.Migrations
{
    public partial class CowsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cows",
                columns: table => new
                {
                    EaringId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Father = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherEaringId = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    Lactation = table.Column<int>(type: "int", nullable: true),
                    LastCalving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InseminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Semen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TreatmenNumber = table.Column<int>(type: "int", nullable: true),
                    USG = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SuccessfullInsemination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MilkingDays = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DaysToCalving = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsAlive = table.Column<bool>(type: "bit", nullable: true),
                    MilksEfficiency = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.EaringId);
                    table.ForeignKey(
                        name: "FK_Cows_Cows_MotherEaringId",
                        column: x => x.MotherEaringId,
                        principalTable: "Cows",
                        principalColumn: "EaringId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cows_MotherEaringId",
                table: "Cows",
                column: "MotherEaringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cows");
        }
    }
}
