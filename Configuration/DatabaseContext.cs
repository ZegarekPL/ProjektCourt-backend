using project_court_backend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace project_court_backend.Configuration;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public required DbSet<Grade> Grades { get; init; } // init bo ma byc utworzona tylko raz
}
