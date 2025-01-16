using project_court_backend.Models.DTO.Grade;
using project_court_backend.Models.DTO.User;
using project_court_backend.Models.Entity;

namespace project_court_backend.Models.Mapper;

public class UserMapper
{
    public static UserResponse Map(User user)
    {
        return new UserResponse { Id = user.Id, name = user.name, email = user.email, role = user.role };
    }

    public static User Map(UserRequest userRequest)
    {
        return new User {name = userRequest.name, email = userRequest.email, password = userRequest.password};
    }
}