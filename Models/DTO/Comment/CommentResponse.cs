namespace project_court_backend.Models.DTO.Comment;

public class CommentResponse
{
    public string content { get; set; }
    public int userId { get; set; }
    public int courtId { get; set; }
}