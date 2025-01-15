using HttpExceptions.Exceptions;
using project_court_backend.Services;
using Microsoft.AspNetCore.Mvc;
using project_court_backend.Models.DTO.User;
using project_court_backend.Models.Entity;

namespace project_court_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    /// <summary>Get all users</summary>
    /// <response code="200">Success</response>
    [HttpGet]
    public List<UserResponse> GetAll()
    {
        return userService.getAllUsers();
    }
    
    /// <summary>Add new user</summary>
    /// <response code ="400">User already exists</response>
    /// <response code="200">Success</response>
    [HttpPost]
    public void addUser([FromBody]UserRequest userRequest)    //FromQuery bierze z parametr�w
    {
        userService.addUser(userRequest);
    } 
    
    /// <summary>Get logged in user</summary>
    /// <response code="200">Success</response>
    [HttpGet("me")]
    public List<UserResponse> GetLoggedInUsers()
    {
        return userService.getAdminUser();
    }
    
    /// <summary>Change user role</summary>
    /// <param name="userId">ID of the user whose role is to be changed</param>
    /// <param name="newRole">The new role to assign to the user</param>
    /// <response code="400">User doesn't exist or role is the same</response>
    /// <response code="200">Role updated successfully</response>
    [HttpPut("{userId}/role")]
    public IActionResult ChangeRole(int userId, [FromQuery] Role newRole)
    {
        try
        {
            userService.changeRole(userId, newRole);
            return Ok("Role updated successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (BadRequestException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

