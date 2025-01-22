using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_court_backend.Migrations
{
    /// <inheritdoc />
    public partial class StoredProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION InsertGrade(
                    p_user_id INT,
                    p_grade DOUBLE PRECISION,
                    p_court_id INT
                )
                RETURNS VOID AS
                $$
                DECLARE
                    v_average_grade DOUBLE PRECISION;
                BEGIN
                    --'Procedura składowana'
                    INSERT INTO ""Grades"" (""UserId"", ""grade"", ""CourtId"")
                    VALUES (p_user_id, p_grade, p_court_id);

                    SELECT AVG(""grade"") INTO v_average_grade
                    FROM ""Grades""
                    WHERE ""UserId"" = p_user_id;

                    UPDATE ""User""
                    SET ""averageGrade"" = v_average_grade
                    WHERE ""Id"" = p_user_id;
                END;
                $$
                LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
