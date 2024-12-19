using System.ComponentModel.DataAnnotations;

namespace project_court_backend.Models.Entity;

public class Grade
{
    [Key] public int Id { get; set; }
    public double value { get; set; }
}
