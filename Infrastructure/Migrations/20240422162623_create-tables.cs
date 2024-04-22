using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Apartment = table.Column<int>(type: "int", nullable: true),
                    DateOfChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdultPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportAdultPatientId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    AdultPatientId = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.AdultPatientId);
                    table.ForeignKey(
                        name: "FK_Passports_AdultPatients_AdultPatientId",
                        column: x => x.AdultPatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnthropometryOfPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnthropometryOfPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnthropometryOfPatients_AdultPatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BirthCertificates",
                columns: table => new
                {
                    LittlePatientId = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthCertificates", x => x.LittlePatientId);
                });

            migrationBuilder.CreateTable(
                name: "LittlePatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthCertificateLittlePatientId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LittlePatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LittlePatients_BirthCertificates_BirthCertificateLittlePatientId",
                        column: x => x.BirthCertificateLittlePatientId,
                        principalTable: "BirthCertificates",
                        principalColumn: "LittlePatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodAnalysises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "float", nullable: false),
                    HDL = table.Column<double>(type: "float", nullable: false),
                    LDL = table.Column<double>(type: "float", nullable: false),
                    VLDL = table.Column<double>(type: "float", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "float", nullable: false),
                    BMI = table.Column<double>(type: "float", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodAnalysises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodAnalysises_AdultPatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodAnalysises_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodAnalysises_LittlePatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "LittlePatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lifestyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "bit", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    Sport = table.Column<bool>(type: "bit", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifestyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lifestyles_AdultPatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lifestyles_LittlePatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "LittlePatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AdultPatients_PassportAdultPatientId",
                table: "AdultPatients",
                column: "PassportAdultPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AnthropometryOfPatients_PatientId",
                table: "AnthropometryOfPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodAnalysises_EmployeeId",
                table: "BloodAnalysises",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodAnalysises_PatientId",
                table: "BloodAnalysises",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifestyles_PatientId",
                table: "Lifestyles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LittlePatients_BirthCertificateLittlePatientId",
                table: "LittlePatients",
                column: "BirthCertificateLittlePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_EmployeeId",
                table: "RefreshTokens",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AdultPatients_PatientId",
                table: "Addresses",
                column: "PatientId",
                principalTable: "AdultPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_LittlePatients_PatientId",
                table: "Addresses",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdultPatients_Passports_PassportAdultPatientId",
                table: "AdultPatients",
                column: "PassportAdultPatientId",
                principalTable: "Passports",
                principalColumn: "AdultPatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnthropometryOfPatients_LittlePatients_PatientId",
                table: "AnthropometryOfPatients",
                column: "PatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_LittlePatients_LittlePatientId",
                table: "BirthCertificates",
                column: "LittlePatientId",
                principalTable: "LittlePatients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passports_AdultPatients_AdultPatientId",
                table: "Passports");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_LittlePatients_LittlePatientId",
                table: "BirthCertificates");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AnthropometryOfPatients");

            migrationBuilder.DropTable(
                name: "BloodAnalysises");

            migrationBuilder.DropTable(
                name: "Lifestyles");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AdultPatients");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "LittlePatients");

            migrationBuilder.DropTable(
                name: "BirthCertificates");
        }
    }
}
