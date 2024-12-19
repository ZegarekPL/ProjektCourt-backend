using project_court_backend.Models.DTO.Grade;
using project_court_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace project_court_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController(GradeService gradeService) : ControllerBase
{
    /// <summary>Get all grades</summary>
    [HttpGet]
    public List<GradeResponse> GetAll()
    {
        return gradeService.getAll();
    }

    /// <summary>Add new grade</summary>
    /// <response code ="400">Grade already exists</response>
    [HttpPost]
    public void add([FromBody]GradeRequest gradeRequest)    //FromQuery bierze z parametr�w
    {
        gradeService.add(gradeRequest);
    } 
}

