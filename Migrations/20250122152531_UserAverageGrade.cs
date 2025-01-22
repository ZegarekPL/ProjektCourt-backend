using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_court_backend.Migrations
{
    /// <inheritdoc />
    public partial class UserAverageGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "averageGrade",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "averageGrade",
                table: "User");
        }
    }
}
