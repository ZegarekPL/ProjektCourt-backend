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
    [HttpGet("/api/court/getAll")]
    public async Task<List<CourtResponse>> GetAllCourts()
    {
        return await courtService.getAllCourts();
    }
    
    /// <summary>Get court by Id</summary>
    /// <response code="200">Success</response>
    [HttpGet("/api/court/{courtId}/user/{userId}")]
    public async Task<CourtResponse> GetCourtById(int courtId, int userId)
    {
        return await courtService.getCourtById(courtId, userId);
    }

    /// <summary>Add new court</summary>
    /// <response code ="400">Court already exists</response>
    /// <response code="200">Success</response>
    [HttpPost("/api/court/add")]
    public void addCourt([FromBody]CourtRequest courtRequest)
    {
        courtService.addCourt(courtRequest);
    } 
    
    /// <summary>Delete court</summary>
    /// <response code ="400">Court already exists</response>
    /// <response code="200">Success</response>
    [HttpDelete("/api/court/{courtId}/delete")]
    public void deleteCourt(int courtId)
    {
        courtService.deleteCourt(courtId);
    } 
    
    [HttpPut("/api/court/{courtId}/edit")]
    public void UpdateCourt(int courtId, [FromBody] CourtRequest courtRequest)
    {
        courtService.updateCourt(courtId, courtRequest);
    }
}

