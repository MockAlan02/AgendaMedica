using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class Datab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_LaboratoryTestId",
                table: "LaboratoryResults");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResults_ConsultingRoomId",
                table: "LaboratoryResults",
                column: "ConsultingRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_ConsultingRoomId",
                table: "LaboratoryResults",
                column: "ConsultingRoomId",
                principalTable: "ConsultingRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_ConsultingRoomId",
                table: "LaboratoryResults");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryResults_ConsultingRoomId",
                table: "LaboratoryResults");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_LaboratoryTestId",
                table: "LaboratoryResults",
                column: "LaboratoryTestId",
                principalTable: "ConsultingRooms",
                principalColumn: "Id");
        }
    }
}
