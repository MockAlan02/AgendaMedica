using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persitence.Migrations
{
    /// <inheritdoc />
    public partial class AddLaboratoryResultssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "LaboratoryResults",
                type: "nvarchar(240)",
                maxLength: 240,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "LaboratoryResults",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(240)",
                oldMaxLength: 240);
        }
    }
}
