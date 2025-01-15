using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_court_backend.Models.Entity;

public class Comment
{
    [Key] public int Id { get; set; }
    [Required] public string Content { get; set; }
    [Required] public int UserId { get; set; }
    
    [ForeignKey("CourtId")] 
    public int CourtId { get; set; }
    public Court Court { get; set; }
}