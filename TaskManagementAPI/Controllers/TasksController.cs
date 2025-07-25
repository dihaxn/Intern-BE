using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {


        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }



        // GET: api/tasks
        [HttpGet]
        public ActionResult<ApiResponse<List<TaskItem>>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();

            return Ok(new ApiResponse<List<TaskItem>>
            {
                Success = true,
                Message = $"Retrieved {tasks.Count} tasks successfully",
                Data = tasks
            });
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public ActionResult<ApiResponse<TaskItem>> GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound(new ApiResponse<TaskItem>
                {
                    Success = false,
                    Message = $"Task with ID {id} not found"
                });
            }

            return Ok(new ApiResponse<TaskItem>
            {
                Success = true,
                Message = "Task retrieved successfully",
                Data = task
            });
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<ApiResponse<TaskItem>> CreateTask(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest(new ApiResponse<TaskItem>
                {
                    Success = false,
                    Message = "Task title is required"
                });
            }

            var createdTask = _taskService.CreateTask(task);

            return CreatedAtAction(
                nameof(GetTask),
                new { id = createdTask.Id },
                new ApiResponse<TaskItem>
                {
                    Success = true,
                    Message = "Task created successfully",
                    Data = createdTask
                });
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public ActionResult<ApiResponse<TaskItem>> UpdateTask(int id, TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest(new ApiResponse<TaskItem>
                {
                    Success = false,
                    Message = "Task title is required"
                });
            }

            var updatedTask = _taskService.UpdateTask(id, task);

            if (updatedTask == null)
            {
                return NotFound(new ApiResponse<TaskItem>
                {
                    Success = false,
                    Message = $"Task with ID {id} not found"
                });
            }

            return Ok(new ApiResponse<TaskItem>
            {
                Success = true,
                Message = "Task updated successfully",
                Data = updatedTask
            });
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse<object>> DeleteTask(int id)
        {
            var deleted = _taskService.DeleteTask(id);

            if (!deleted)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Task with ID {id} not found"
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Task deleted successfully"
            });
        }

        // GET: api/tasks/user/5
        [HttpGet("user/{userId}")]
        public ActionResult<ApiResponse<List<TaskItem>>> GetTasksByUser(int userId)
        {
            var tasks = _taskService.GetTasksByUserId(userId);

            return Ok(new ApiResponse<List<TaskItem>>
            {
                Success = true,
                Message = $"Retrieved {tasks.Count} tasks for user {userId}",
                Data = tasks
            });
        }

        // GET: api/tasks/stats
        [HttpGet("stats")]
        public ActionResult<ApiResponse<object>> GetTaskStats()
        {
            var allTasks = _taskService.GetAllTasks();

            var stats = new
            {
                TotalTasks = allTasks.Count,
                CompletedTasks = allTasks.Count(t => t.IsCompleted),
                PendingTasks = allTasks.Count(t => !t.IsCompleted),
                HighPriorityTasks = allTasks.Count(t => t.Priority == TaskPriority.High || t.Priority == TaskPriority.Critical),
                OverdueTasks = allTasks.Count(t => t.DueDate.HasValue && t.DueDate < DateTime.UtcNow && !t.IsCompleted)
            };

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Task statistics retrieved successfully",
                Data = stats
            });
        }
    }
}