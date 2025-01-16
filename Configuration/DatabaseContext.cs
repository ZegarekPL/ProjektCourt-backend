using project_court_backend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace project_court_backend.Configuration;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public required DbSet<Comment> Comment { get; init; }
    public required DbSet<Court> Court { get; init; } 
    public required DbSet<Grade> Grades { get; init; }
    public required DbSet<SurfaceType> SurfaceType { get; init; }
    public required DbSet<User> User { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SurfaceType>().HasData(
            new SurfaceType { Id = 1, surfaceType = "Trawiaste" },
            new SurfaceType { Id = 2, surfaceType = "Mączka" },
            new SurfaceType { Id = 3, surfaceType = "Akryl" }
        );
    }
}
