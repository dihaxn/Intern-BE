using System;

using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new()
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", CreatedDate = DateTime.UtcNow.AddDays(-30) },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", CreatedDate = DateTime.UtcNow.AddDays(-20) }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<ApiResponse<List<User>>> GetAllUsers()
        {
            return Ok(new ApiResponse<List<User>>
            {
                Success = true,
                Message = $"Retrieved {_users.Count} users successfully",
                Data = _users
            });
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public ActionResult<ApiResponse<User>> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new ApiResponse<User>
                {
                    Success = false,
                    Message = $"User with ID {id} not found"
                });
            }

            return Ok(new ApiResponse<User>
            {
                Success = true,
                Message = "User retrieved successfully",
                Data = user
            });
        }
    }
}
