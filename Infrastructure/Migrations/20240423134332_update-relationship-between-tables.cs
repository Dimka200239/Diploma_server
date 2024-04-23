using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationshipbetweentables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdultPatients_Passports_PassportAdultPatientId",
                table: "AdultPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_LittlePatients_BirthCertificates_BirthCertificateLittlePatientId",
                table: "LittlePatients");

            migrationBuilder.DropIndex(
                name: "IX_LittlePatients_BirthCertificateLittlePatientId",
                table: "LittlePatients");

            migrationBuilder.DropIndex(
                name: "IX_AdultPatients_PassportAdultPatientId",
                table: "AdultPatients");

            migrationBuilder.DropColumn(
                name: "BirthCertificateLittlePatientId",
                table: "LittlePatients");

            migrationBuilder.DropColumn(
                name: "PassportAdultPatientId",
                table: "AdultPatients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthCertificateLittlePatientId",
                table: "LittlePatients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassportAdultPatientId",
                table: "AdultPatients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LittlePatients_BirthCertificateLittlePatientId",
                table: "LittlePatients",
                column: "BirthCertificateLittlePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AdultPatients_PassportAdultPatientId",
                table: "AdultPatients",
                column: "PassportAdultPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultPatients_Passports_PassportAdultPatientId",
                table: "AdultPatients",
                column: "PassportAdultPatientId",
                principalTable: "Passports",
                principalColumn: "AdultPatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LittlePatients_BirthCertificates_BirthCertificateLittlePatientId",
                table: "LittlePatients",
                column: "BirthCertificateLittlePatientId",
                principalTable: "BirthCertificates",
                principalColumn: "LittlePatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
