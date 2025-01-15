using project_court_backend.Models.DTO.SurfaceType;
using project_court_backend.Models.Entity;

namespace project_court_backend.Models.Mapper;

public class SurfaceTypeMapper
{
    public static SurfaceTypeResponse Map(SurfaceType surfaceType)
    {
        return new SurfaceTypeResponse() { Id = surfaceType.Id, surfaceType = surfaceType.surfaceType };
    }

    public static SurfaceType Map(SurfaceTypeRequest surfaceTypeRequest)
    {
        return new SurfaceType {surfaceType = surfaceTypeRequest.surfaceType };
    }
}