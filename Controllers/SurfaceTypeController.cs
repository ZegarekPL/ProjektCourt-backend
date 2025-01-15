using Microsoft.AspNetCore.Mvc;
using project_court_backend.Models.DTO.SurfaceType;
using project_court_backend.Services;

namespace project_court_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SurfaceTypeController(SurfaceTypeService surfaceTypeService)
{
    /// <summary>Get all Surface Type</summary>
    /// <response code="200">Success</response>
    [HttpGet("/api/surfaceType/")]
    public List<SurfaceTypeResponse> GetAll()
    {
        return surfaceTypeService.getAllSurfaceType();
    }

    /// <summary>Add new Surface Type</summary>
    /// <response code ="400">Surface Type already exists</response>
    /// <response code="200">Success</response>
    [HttpPost("/api/surfaceType/addNewSurfaceType")]
    public void add([FromBody]SurfaceTypeRequest surfaceTypeRequest)
    {
        surfaceTypeService.addSurfaceType(surfaceTypeRequest);
    } 
}