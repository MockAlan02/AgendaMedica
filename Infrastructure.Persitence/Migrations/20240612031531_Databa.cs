using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class Databa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "LaboratoryResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResults_AppointmentId",
                table: "LaboratoryResults",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryResults_Appointments_AppointmentId",
                table: "LaboratoryResults",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryResults_Appointments_AppointmentId",
                table: "LaboratoryResults");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryResults_AppointmentId",
                table: "LaboratoryResults");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "LaboratoryResults");
        }
    }
}
