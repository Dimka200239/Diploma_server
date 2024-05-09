using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletetableswithinfoaboutlittlepatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_LittlePatients_PatientId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AnthropometryOfPatients_LittlePatients_PatientId",
                table: "AnthropometryOfPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodAnalysises_LittlePatients_PatientId",
                table: "BloodAnalysises");

            migrationBuilder.DropForeignKey(
                name: "FK_Lifestyles_LittlePatients_PatientId",
                table: "Lifestyles");

            migrationBuilder.DropTable(
                name: "BirthCertificates");

            migrationBuilder.DropTable(
                name: "LittlePatientAdultPatientMaps");

            migrationBuilder.DropTable(
                name: "LittlePatients");

            migrationBuilder.AddColumn<double>(
                name: "WHI",
                table: "BloodAnalysises",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AnthropometryOfPatients",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "AnthropometryOfPatients",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Hip",
                table: "AnthropometryOfPatients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Waist",
                table: "AnthropometryOfPatients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WHI",
                table: "BloodAnalysises");

            migrationBuilder.DropColumn(
                name: "Hip",
                table: "AnthropometryOfPatients");

            migrationBuilder.DropColumn(
                name: "Waist",
                table: "AnthropometryOfPatients");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "AnthropometryOfPatients",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "AnthropometryOfPatients",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "LittlePatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LittlePatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirthCertificates",
                columns: table => new
                {
                    LittlePatientId = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthCertificates", x => x.LittlePatientId);
                    table.ForeignKey(
                        name: "FK_BirthCertificates_LittlePatients_LittlePatientId",
                        column: x => x.LittlePatientId,
                        principalTable: "LittlePatients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LittlePatientAdultPatientMaps",
                columns: table => new
                {
                    AdultPatientId = table.Column<int>(type: "int", nullable: false),
                    LittlePatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LittlePatientAdultPatientMaps", x => new { x.AdultPatientId, x.LittlePatientId });
                    table.ForeignKey(
                        name: "FK_LittlePatientAdultPatientMaps_AdultPatients_AdultPatientId",
                        column: x => x.AdultPatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LittlePatientAdultPatientMaps_LittlePatients_LittlePatientId",
                        column: x => x.LittlePatientId,
                        principalTable: "LittlePatients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LittlePatientAdultPatientMaps_AdultPatientId",
                table: "LittlePatientAdultPatientMaps",
                column: "AdultPatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LittlePatientAdultPatientMaps_LittlePatientId",
                table: "LittlePatientAdultPatientMaps",
                column: "LittlePatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_LittlePatients_PatientId",
                table: "Addresses",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnthropometryOfPatients_LittlePatients_PatientId",
                table: "AnthropometryOfPatients",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodAnalysises_LittlePatients_PatientId",
                table: "BloodAnalysises",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lifestyles_LittlePatients_PatientId",
                table: "Lifestyles",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
