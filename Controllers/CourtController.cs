using project_court_backend.Services;
using Microsoft.AspNetCore.Mvc;
using project_court_backend.Models.DTO.Court;

namespace project_court_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CourtController(CourtService courtService) : ControllerBase
{
    /// <summary>Get all courts</summary>
    /// <response code="200">Success</response>
    [HttpGet]
    public async Task<List<CourtResponse>> GetAllCourts()
    {
        return await courtService.getAllCourts();
    }

    /// <summary>Add new court</summary>
    /// <response code ="400">Court already exists</response>
    /// <response code="200">Success</response>
    [HttpPost]
    public void addCourt([FromBody]CourtRequest courtRequest)
    {
        courtService.addCourt(courtRequest);
    } 
    
    /// <summary>Delete court</summary>
    /// <response code ="400">Court already exists</response>
    /// <response code="200">Success</response>
    [HttpDelete("{courtId}")]
    public void deleteCourt(int courtId)
    {
        courtService.deleteCourt(courtId);
    } 
    
    [HttpPut("{courtId}")]
    public void UpdateCourt(int courtId, [FromBody] CourtRequest courtRequest)
    {
        courtService.updateCourt(courtId, courtRequest);
    }
}

