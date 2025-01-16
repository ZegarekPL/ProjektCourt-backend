using project_court_backend.Models.DTO.Grade;
using project_court_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace project_court_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController(GradeService gradeService) : ControllerBase
{
    /// <summary>Get all grades</summary>
    /// <response code="200">Grade add successfully</response>
    [HttpGet("/api/grade/getAll")]
    public List<GradeResponse> GetAll()
    {
        return gradeService.getAllGrades();
    }

    /// <summary>Add new grade</summary>
    /// <param name="userId">User Id</param>
    /// <param name="courtId">Court Id</param>
    /// <response code="400">Grade already exists</response>
    /// <response code="200">Grade add successfully</response>
    [HttpPost("/api/grade/{userId}/court/{courtId}")]
    public void addGrade(int userId, int courtId, [FromBody]GradeRequest gradeRequest)
    {
        gradeService.addGrade(userId, courtId, gradeRequest);
    } 
    
    /// <summary>Edit grade</summary>
    /// <param name="userId">User Id</param>
    /// <param name="courtId">Court Id</param>
    /// <response code="200">Grade edit successfully</response>
    [HttpPut("/api/grade/{userId}/court/{courtId}")]
    public void editGrade(int userId, int courtId, [FromBody]GradeRequest gradeRequest)
    {
        gradeService.editGrade(userId, courtId, gradeRequest.grade);
    } 
}

