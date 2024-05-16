using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtablesformachinelearning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataForFutureLearning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "bit", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Sport = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "float", nullable: false),
                    HDL = table.Column<double>(type: "float", nullable: false),
                    LDL = table.Column<double>(type: "float", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "float", nullable: false),
                    WHI = table.Column<double>(type: "float", nullable: false),
                    HasCVD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataForFutureLearning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateForForecasting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "bit", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Sport = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "float", nullable: false),
                    HDL = table.Column<double>(type: "float", nullable: false),
                    LDL = table.Column<double>(type: "float", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "float", nullable: false),
                    WHI = table.Column<double>(type: "float", nullable: false),
                    HasCVD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateForForecasting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineLearningModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineLearningModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataForFutureLearning");

            migrationBuilder.DropTable(
                name: "DateForForecasting");

            migrationBuilder.DropTable(
                name: "MachineLearningModel");
        }
    }
}
