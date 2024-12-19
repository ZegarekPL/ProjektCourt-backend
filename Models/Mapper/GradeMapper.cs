using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.Entity;

namespace project_court_backend.Models.Mapper;

public class GradeMapper
{
    public static GradeResponse Map(Grade grade)
    {
        return new GradeResponse { Id = grade.Id, value = grade.value };
    }

    public static Grade Map(GradeRequest gradeRequest)
    {
        return new Grade {value = gradeRequest.value };
    }
}
