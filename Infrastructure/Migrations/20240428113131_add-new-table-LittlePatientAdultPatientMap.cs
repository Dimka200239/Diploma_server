using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewtableLittlePatientAdultPatientMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LittlePatientAdultPatientMaps");
        }
    }
}
