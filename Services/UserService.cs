using HttpExceptions.Exceptions;
using project_court_backend.Configuration;
using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.DTO.User;
using project_court_backend.Models.Entity;
using project_court_backend.Models.Mapper;

namespace project_court_backend.Services;

public class UserService(DatabaseContext databaseContext)
{
    public List<UserResponse> getAllUsers()
    {
        return databaseContext.User.Select(u => UserMapper.Map(u)).ToList();
    }
    
    public UserResponse getAdminUser()
    {
        var adminUser = databaseContext.User
            .Where(u => u.role == Role.Admin)
            .FirstOrDefault();
        
        if (adminUser == null)
        {
            adminUser = databaseContext.User
                .Where(u => u.role == Role.User)
                .FirstOrDefault();
        }
        
        if (adminUser != null)
        {
            return new UserResponse
            {
                Id = adminUser.Id,
                name = adminUser.name,
                email = adminUser.email,
                role = adminUser.role
            };
        }
        
        return new UserResponse();
    }


    public UserResponse GetUserById(int userId)
    {
        var user = databaseContext.User.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return null;
        }

        return UserMapper.Map(user);
    }
    
    public void addUser(UserRequest userRequest)
    {
        if (databaseContext.User.Any(u => u.email == userRequest.email)) {
            throw new BadRequestException("Email already exist");
        }
        databaseContext.User.Add(UserMapper.Map(userRequest));
        databaseContext.SaveChanges();
    }
    
    public void changeRole(int userId, Role newRole)
    {
        var user = databaseContext.User.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        
        if (user.role == newRole)
        {
            throw new BadRequestException("Role is the same");
        }
        user.role = newRole;
        databaseContext.SaveChanges();
    }
}