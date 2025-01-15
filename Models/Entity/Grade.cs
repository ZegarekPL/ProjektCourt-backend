using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_court_backend.Models.Entity;

public class Grade
{
    [Key] public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public double grade { get; set; }
    
    [ForeignKey("CourtId")]
    public int CourtId { get; set; }
    public Court court { get; set; }
}
