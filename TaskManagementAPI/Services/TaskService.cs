using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();
        TaskItem? GetTaskById(int id);
        TaskItem CreateTask(TaskItem task);
        TaskItem? UpdateTask(int id, TaskItem task);
        bool DeleteTask(int id);
        List<TaskItem> GetTasksByUserId(int userId);
    }

    public class TaskService : ITaskService
    {
        private static List<TaskItem> _tasks = new()
        {
            new TaskItem
            {
                Id = 1,
                Title = "Setup Development Environment",
                Description = "Install .NET 8 SDK and configure IDE",
                IsCompleted = true,
                CreatedDate = DateTime.UtcNow.AddDays(-5),
                DueDate = DateTime.UtcNow.AddDays(-3),
                Priority = TaskPriority.High,
                UserId = 1
            },
            new TaskItem
            {
                Id = 2,
                Title = "Learn ASP.NET Core Basics",
                Description = "Understand controllers, models, and routing",
                IsCompleted = false,
                CreatedDate = DateTime.UtcNow.AddDays(-3),
                DueDate = DateTime.UtcNow.AddDays(2),
                Priority = TaskPriority.Medium,
                UserId = 1
            },
            new TaskItem
            {
                Id = 3,
                Title = "Build Sample API",
                Description = "Create a task management API project",
                IsCompleted = false,
                CreatedDate = DateTime.UtcNow.AddDays(-1),
                DueDate = DateTime.UtcNow.AddDays(7),
                Priority = TaskPriority.High,
                UserId = 2
            }
        };

        private static int _nextId = 4;

        public List<TaskItem> GetAllTasks()
        {
            return _tasks.OrderByDescending(t => t.CreatedDate).ToList();
        }

        public TaskItem? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskItem CreateTask(TaskItem task)
        {
            task.Id = _nextId++;
            task.CreatedDate = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }

        public TaskItem? UpdateTask(int id, TaskItem updatedTask)
        {
            var existingTask = GetTaskById(id);
            if (existingTask == null) return null;

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.IsCompleted = updatedTask.IsCompleted;
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.Priority = updatedTask.Priority;
            existingTask.UserId = updatedTask.UserId;

            return existingTask;
        }

        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task == null) return false;

            _tasks.Remove(task);
            return true;
        }

        public List<TaskItem> GetTasksByUserId(int userId)
        {
            return _tasks.Where(t => t.UserId == userId)
                         .OrderByDescending(t => t.CreatedDate)
                         .ToList();
        }
    }
}
