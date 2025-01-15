using Microsoft.EntityFrameworkCore;
using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Comment;
using project_court_backend.Models.DTO.Court;
using project_court_backend.Models.Entity;

namespace project_court_backend.Models.Mapper;

public class CourtMapper
{
    public static async Task<CourtResponse> MapAsync(Court court, DatabaseContext databaseContext)
    {
        // Asynchroniczne pobranie ocen z tabeli Grades
        var gradesCount = await databaseContext.Grades
            .Where(g => g.CourtId == court.Id)  // Filtrujemy oceny po CourtId
            .GroupBy(g => g.grade)  // Grupujemy oceny według wartości grade
            .ToDictionaryAsync(g => g.Key, g => g.Count());  // Tworzymy słownik, gdzie klucz to grade, a wartość to liczba wystąpień

        return new CourtResponse
        {
            Id = court.Id,
            name = court.name,
            localization = court.localization,
            surfaceType = court.surfaceType,
            comments = court.comments.Select(c => new CommentResponse
            {
                content = c.Content,
                userId = c.UserId,
                courtId = c.CourtId
            }).ToList(),
            grades = new GradeResponseToCourt
            {
                grade1 = gradesCount.ContainsKey(1) ? gradesCount[1] : 0,
                grade2 = gradesCount.ContainsKey(2) ? gradesCount[2] : 0,
                grade3 = gradesCount.ContainsKey(3) ? gradesCount[3] : 0,
                grade4 = gradesCount.ContainsKey(4) ? gradesCount[4] : 0,
                grade5 = gradesCount.ContainsKey(5) ? gradesCount[5] : 0
            }
        };
    }
    
    public static Court Map(CourtRequest courtRequest)
    {
        return new Court { name = courtRequest.name, localization = courtRequest.localization, surfaceType = courtRequest.surfaceType };
    }
}