using HttpExceptions.Exceptions;
using project_court_backend.Configuration;
using project_court_backend.Models.DTO.SurfaceType;
using project_court_backend.Models.Mapper;

namespace project_court_backend.Services;

public class SurfaceTypeService(DatabaseContext databaseContext)
{
    public List<SurfaceTypeResponse> getAllSurfaceType()
    {
        return databaseContext.SurfaceType.Select(g => SurfaceTypeMapper.Map(g)).ToList();
    }

    public void addSurfaceType(SurfaceTypeRequest surfaceTypeRequest)
    {
        if (databaseContext.SurfaceType.Any(s => s.surfaceType == surfaceTypeRequest.surfaceType)) {
            throw new BadRequestException("SurfaceType already exist");
        }
        databaseContext.SurfaceType.Add(SurfaceTypeMapper.Map(surfaceTypeRequest));
        databaseContext.SaveChanges();
    }
}