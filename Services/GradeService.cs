using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.Mapper;
using HttpExceptions.Exceptions;

namespace project_court_backend.Services;

public class GradeService(DatabaseContext databaseContext)
{
    public List<GradeResponse> getAll()
    {
        return databaseContext.Grades.Select(g => GradeMapper.Map(g)).ToList();
    }

    public void add(GradeRequest gradeRequest)
    {
        if (databaseContext.Grades.Any(g => g.value == gradeRequest.value)) {
            throw new BadRequestException("Grade already exist");
        }
        databaseContext.Grades.Add(GradeMapper.Map(gradeRequest));
        databaseContext.SaveChanges();
    }
}
