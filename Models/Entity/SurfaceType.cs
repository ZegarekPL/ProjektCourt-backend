using System.ComponentModel.DataAnnotations;

namespace project_court_backend.Models.Entity;

public class SurfaceType
{
    [Key] public int Id { get; set; }
    public string surfaceType { get; set; }
}