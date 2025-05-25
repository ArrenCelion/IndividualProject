using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedShapesModelandremovedallindividualshapemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parallelograms");

            migrationBuilder.DropTable(
                name: "RectangleModels");

            migrationBuilder.DropTable(
                name: "Triangles");

            migrationBuilder.CreateTable(
                name: "ShapesModels",
                columns: table => new
                {
                    ShapesModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SideB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SideC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapesModels", x => x.ShapesModelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShapesModels");

            migrationBuilder.CreateTable(
                name: "Parallelograms",
                columns: table => new
                {
                    ParallelogramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRhombus = table.Column<bool>(type: "bit", nullable: false),
                    Side = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RectangleModels", x => x.RectangleModelId);
                });

            migrationBuilder.CreateTable(
                name: "Triangles",
                columns: table => new
                {
                    TriangleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Circumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfCalculation = table.Column<DateOnly>(type: "date", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SideC = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triangles", x => x.TriangleId);
                });
        }
    }
}
