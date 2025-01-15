using project_court_backend.Models.DTO.SurfaceType;

namespace project_court_backend.Models.DTO.Court;

public class CourtRequest
{
    public string name { get; set; }
    public string localization { get; set; }
    public string surfaceType { get; set; }
}
