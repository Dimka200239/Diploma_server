using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdultPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrelationValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SmokeCigarettes = table.Column<double>(type: "double precision", nullable: false),
                    DrinkAlcohol = table.Column<double>(type: "double precision", nullable: false),
                    Sport = table.Column<double>(type: "double precision", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "double precision", nullable: false),
                    HDL = table.Column<double>(type: "double precision", nullable: false),
                    LDL = table.Column<double>(type: "double precision", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "double precision", nullable: false),
                    WHI = table.Column<double>(type: "double precision", nullable: false),
                    CountOfData = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrelationValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataForFutureLearning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "boolean", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "boolean", nullable: false),
                    Sport = table.Column<bool>(type: "boolean", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "double precision", nullable: false),
                    HDL = table.Column<double>(type: "double precision", nullable: false),
                    LDL = table.Column<double>(type: "double precision", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "double precision", nullable: false),
                    WHI = table.Column<double>(type: "double precision", nullable: false),
                    HasCVD = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataForFutureLearning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateForForecasting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "boolean", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "boolean", nullable: false),
                    Sport = table.Column<bool>(type: "boolean", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "double precision", nullable: false),
                    HDL = table.Column<double>(type: "double precision", nullable: false),
                    LDL = table.Column<double>(type: "double precision", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "double precision", nullable: false),
                    WHI = table.Column<double>(type: "double precision", nullable: false),
                    HasCVD = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateForForecasting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    IsConfirm = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineLearningModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelData = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CountOfData = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineLearningModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<int>(type: "integer", nullable: false),
                    Apartment = table.Column<int>(type: "integer", nullable: true),
                    DateOfChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AdultPatients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AdultPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnthropometryOfPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Waist = table.Column<double>(type: "double precision", nullable: false),
                    Hip = table.Column<double>(type: "double precision", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "Lifestyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    SmokeCigarettes = table.Column<bool>(type: "boolean", nullable: false),
                    DrinkAlcohol = table.Column<bool>(type: "boolean", nullable: false),
                    Sport = table.Column<bool>(type: "boolean", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    AdultPatientId = table.Column<int>(type: "integer", nullable: false),
                    Series = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "BloodAnalysises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    AmountOfCholesterol = table.Column<double>(type: "double precision", nullable: false),
                    HDL = table.Column<double>(type: "double precision", nullable: false),
                    LDL = table.Column<double>(type: "double precision", nullable: false),
                    VLDL = table.Column<double>(type: "double precision", nullable: false),
                    AtherogenicityCoefficient = table.Column<double>(type: "double precision", nullable: false),
                    BMI = table.Column<double>(type: "double precision", nullable: false),
                    WHI = table.Column<double>(type: "double precision", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId");

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
                name: "IX_RefreshTokens_EmployeeId",
                table: "RefreshTokens",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AnthropometryOfPatients");

            migrationBuilder.DropTable(
                name: "BloodAnalysises");

            migrationBuilder.DropTable(
                name: "CorrelationValue");

            migrationBuilder.DropTable(
                name: "DataForFutureLearning");

            migrationBuilder.DropTable(
                name: "DateForForecasting");

            migrationBuilder.DropTable(
                name: "Lifestyles");

            migrationBuilder.DropTable(
                name: "MachineLearningModel");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AdultPatients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
