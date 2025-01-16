using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Court;
using project_court_backend.Models.Entity;
using project_court_backend.Models.Mapper;

namespace project_court_backend.Services;

    public class CourtService(DatabaseContext databaseContext)
    {

        public async Task<List<CourtResponse>> getAllCourts()
        {
            var courts = await databaseContext.Court
                .ToListAsync();

            var courtResponses = new List<CourtResponse>();

            foreach (var court in courts)
            {
                var courtResponse = await CourtMapper.MapAsync(court, databaseContext);
                courtResponses.Add(courtResponse);
            }

            return courtResponses;
        }

        public async Task<CourtResponse> getCourtById(int courtId)
        {
            var court = await databaseContext.Court
                .FirstOrDefaultAsync(c => c.Id == courtId);
            
            if (court == null)
            {
                throw new NotFoundException("Court not found");
            }
            
            var courtResponse = await CourtMapper.MapAsync(court, databaseContext);
            
            return courtResponse;
        }
        
        public void addCourt(CourtRequest courtRequest)
        {
            var surfaceTypeExists = databaseContext.SurfaceType
                .Any(st => st.surfaceType == courtRequest.surfaceType);

            Console.WriteLine("Surface Type: " + databaseContext.SurfaceType
                .Any(st => st.surfaceType == courtRequest.surfaceType));
                
                
            if (!surfaceTypeExists)
            {
                throw new BadRequestException("The surfaceType doesn't exist");
            }
            
            var courtExists = databaseContext.Court
                .Any(c => c.name == courtRequest.name);

            if (courtExists)
            {
                throw new BadRequestException("A court with the same name already exists");
            }
            
            var court = CourtMapper.Map(courtRequest);
            databaseContext.Court.Add(court);
            databaseContext.SaveChanges();
        }
        
        public void deleteCourt(int courtId)
        {
            var court = databaseContext.Court
                .Include(c => c.comments)
                .FirstOrDefault(c => c.Id == courtId);

            if (court == null)
            {
                throw new NotFoundException("Court not found");
            }
            
            databaseContext.Comment.RemoveRange(court.comments);
            var gradesToDelete = databaseContext.Grades
                .Where(g => g.CourtId == courtId)
                .ToList();
            databaseContext.Grades.RemoveRange(gradesToDelete);
            databaseContext.Court.Remove(court);
            databaseContext.SaveChanges();
        }
        
        public void updateCourt(int courtId, CourtRequest courtRequest)
        {
            var court = databaseContext.Court.FirstOrDefault(c => c.Id == courtId);

            if (court == null)
            {
                throw new NotFoundException("Court not found");
            }
            
            if (!databaseContext.SurfaceType.Any(s => s.surfaceType == courtRequest.surfaceType)) {
                throw new BadRequestException("SurfaceType doesn't exist");
            }
            court.name = courtRequest.name;
            court.localization = courtRequest.localization;
            court.surfaceType = courtRequest.surfaceType;
            
            databaseContext.SaveChanges();
        }
    }
