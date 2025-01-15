using System.ComponentModel.DataAnnotations;

namespace project_court_backend.Models.Entity;

public class User
{
    [Key] public int Id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public Role role { get; set; }
}