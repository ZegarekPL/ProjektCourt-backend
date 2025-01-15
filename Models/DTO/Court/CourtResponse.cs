using project_court_backend.Models.DTO.Comment;
using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.Entity;

namespace project_court_backend.Models.DTO.Court;

public class CourtResponse
{
    public int Id { get; set; }
    public string name { get; set; }
    public string localization { get; set; }
    public string surfaceType { get; set; }
    public List<CommentResponse> comments { get; set; }
    public GradeResponseToCourt grades { get; set; }
}
