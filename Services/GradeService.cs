using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace project_court_backend.Services;

public class GradeService(DatabaseContext databaseContext)
{
    public List<GradeResponse> getAllGrades()
    {
        return databaseContext.Grades.Select(g => GradeMapper.Map(g)).ToList();
    }

    public void addGrade(int userId, int courtId, GradeRequest gradeRequest)
    {
        if (!databaseContext.User.Any(g => g.Id == userId)) {
            throw new BadRequestException("User doesn't exist");
        }
        if (!databaseContext.Court.Any(g => g.Id == courtId)) {
            throw new BadRequestException("Court doesn't exist");
        }
        if (databaseContext.Grades.Any(g => (g.UserId == userId && g.court.Id == courtId))) {
            throw new BadRequestException("User already grade this court");
        }
        if (gradeRequest.grade < 1 || gradeRequest.grade > 5)
        {
            throw new BadRequestException("Grade must be between 1 and 5");
        }

        try
        {
            databaseContext.Database.ExecuteSqlRaw(
                "SELECT InsertGrade({0}, {1}, {2})",
                userId,
                gradeRequest.grade,
                courtId
            );
        }
        catch (Exception e)
        {
            Console.WriteLine("aaaaaaaaaaaaaa");
            throw;
        }
    }
    
    public void editGrade(int userId, int courtId, double newGrade)
    {
        if (!databaseContext.User.Any(g => g.Id == userId)) {
            throw new BadRequestException("User doesn't exist");
        }
        if (!databaseContext.Court.Any(g => g.Id == courtId)) {
            throw new BadRequestException("Court doesn't exist");
        }
        var grade = databaseContext.Grades
            .FirstOrDefault(g => g.UserId == userId && g.CourtId == courtId);
        if (grade == null) {
            throw new BadRequestException("User already grade this court");
        }
        if (newGrade < 1 || newGrade > 5)
        {
            throw new BadRequestException("Grade must be between 1 and 5");
        }
        grade.grade = newGrade;
        
        databaseContext.SaveChanges();
    }
}
