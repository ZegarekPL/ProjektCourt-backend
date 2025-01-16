using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_court_backend.Migrations
{
    /// <inheritdoc />
    public partial class Grade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userGrade",
                table: "Court",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userGrade",
                table: "Court");
        }
    }
}
