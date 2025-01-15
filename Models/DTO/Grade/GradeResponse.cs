namespace project_court_backend.Models.DTO.Grade;

public class GradeResponse
{
    public int Id { get; set; }
    public double grade { get; set; }
    public int courtId { get; set; }
    public int userId { get; set; }
}
