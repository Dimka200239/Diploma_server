using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewtablecorrelationvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrelationValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokeCigarettes = table.Column<double>(type: "float", nullable: false),
                    DrinkAlcohol = table.Column<double>(type: "float", nullable: false),
                    Sport = table.Column<double>(type: "float", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "float", nullable: false),
                    HDL = table.Column<double>(type: "float", nullable: false),
                    LDL = table.Column<double>(type: "float", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "float", nullable: false),
                    WHI = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrelationValue", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrelationValue");
        }
    }
}
