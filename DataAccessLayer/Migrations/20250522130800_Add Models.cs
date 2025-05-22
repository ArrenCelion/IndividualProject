using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculators",
                columns: table => new
                {
                    CalculatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Number2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCalculation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculators", x => x.CalculatorId);
                });

            migrationBuilder.CreateTable(
                name: "Parallelograms",
                columns: table => new
                {
                    ParallelogramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Side = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false),
                    IsRhombus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parallelograms", x => x.ParallelogramId);
                });

            migrationBuilder.CreateTable(
                name: "RectangleModels",
                columns: table => new
                {
                    RectangleModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RectangleModels", x => x.RectangleModelId);
                });

            migrationBuilder.CreateTable(
                name: "RockPaperScissors",
                columns: table => new
                {
                    RockPaperScissorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfGame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GamesWonAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockPaperScissors", x => x.RockPaperScissorId);
                });

            migrationBuilder.CreateTable(
                name: "Triangles",
                columns: table => new
                {
                    TriangleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triangles", x => x.TriangleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculators");

            migrationBuilder.DropTable(
                name: "Parallelograms");

            migrationBuilder.DropTable(
                name: "RectangleModels");

            migrationBuilder.DropTable(
                name: "RockPaperScissors");

            migrationBuilder.DropTable(
                name: "Triangles");
        }
    }
}
