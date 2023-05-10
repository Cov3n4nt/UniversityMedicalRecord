using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityMedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class changetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPosition",
                table: "Users",
                newName: "EmployeePosition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeePosition",
                table: "Users",
                newName: "UserPosition");
        }
    }
}
