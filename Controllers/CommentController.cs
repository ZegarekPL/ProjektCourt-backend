// using Microsoft.AspNetCore.Mvc;
// using project_court_backend.Models.DTO.Comment;
// using project_court_backend.Services;
//
// namespace project_court_backend.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class CommentController(CommentService commentService) : ControllerBase
// {
//     /// <summary>Get all comment for court</summary>
//     /// <param name="courtId">Court Id</param>
//     /// <response code="200">Success</response>
//     [HttpGet("/api/comment/{courtId}")]
//     public List<CommentResponse> GetAll(int courtId)
//     {
//         return commentService.getAllComments(courtId);
//     }
//
//     /// <summary>Add new comment for court</summary>
//     /// <param name="userId">User Id</param>
//     /// <param name="courtId">Court Id</param>
//     /// <response code="400">Court already exists</response>
//     /// <response code="200">Success</response>
//     [HttpPost("/api/comment/user/{userId}/court/{courtId}")]
//     public void addComment(int userId, int courtId, [FromBody]CommentRequest commentRequest)    //FromQuery bierze z parametr�w
//     {
//         commentService.addComment(userId,  courtId, commentRequest.content);
//     } 
// } 