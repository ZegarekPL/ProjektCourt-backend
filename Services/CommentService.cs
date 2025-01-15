using HttpExceptions.Exceptions;
using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Comment;
using project_court_backend.Models.Entity;

namespace project_court_backend.Services;

public class CommentService(DatabaseContext databaseContext)
{
    public List<CommentResponse> getAllComments(int courtId)
    {
        if (!databaseContext.Court.Any(c => c.Id == courtId))
        {
            throw new NotFoundException("Court not found");
        }
        
        return databaseContext.Comment
            .Where(c => c.CourtId == courtId)
            .Select(c => new CommentResponse
            {
                content = c.Content,
                userId = c.UserId,
                courtId = c.CourtId
            })
            .ToList();
    }
    
    public void addComment(int userId, int courtId, string content)
    {
        if (!databaseContext.Court.Any(c => c.Id == courtId))
        {
            throw new NotFoundException("Court not found");
        }
        
        var userAlreadyCommented = databaseContext.Comment
            .Any(c => c.CourtId == courtId && c.UserId == userId);

        if (userAlreadyCommented)
        {
            throw new BadRequestException("User has already commented on this court");
        }
        
        var comment = new Comment
        {
            CourtId = courtId,
            UserId = userId,
            Content = content
        };

        databaseContext.Comment.Add(comment);
        databaseContext.SaveChanges();
    }
}
