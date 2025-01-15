using System.ComponentModel.DataAnnotations;

namespace project_court_backend.Models.Entity;

public class Court
{
    [Key] public int Id { get; set; }
    public string name { get; set; }
    public string localization { get; set; }
    public string surfaceType { get; set; }
    public List<Comment> comments { get; set; } = new List<Comment>();
    public List<Grade> grades { get; set; } = new List<Grade>();
}