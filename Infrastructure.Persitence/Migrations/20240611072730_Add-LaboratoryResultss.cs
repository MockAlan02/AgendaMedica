using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class AddLaboratoryResultss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultingRoomId",
                table: "LaboratoryResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_LaboratoryTestId",
                table: "LaboratoryResults",
                column: "LaboratoryTestId",
                principalTable: "ConsultingRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryResults_ConsultingRooms_LaboratoryTestId",
                table: "LaboratoryResults");

            migrationBuilder.DropColumn(
                name: "ConsultingRoomId",
                table: "LaboratoryResults");
        }
    }
}
