using project_court_backend.Models.Entity;

namespace project_court_backend.Models.DTO.User;

public class UserResponse
{
    public int Id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public Role role { get; set; }
}
