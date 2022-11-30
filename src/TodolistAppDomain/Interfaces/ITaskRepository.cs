using Microsoft.AspNetCore.Mvc;

namespace TodolistAppDomain.Interfaces;

public interface ITaskRepository
{
    Task<TodolistAppModels.Entities.Task> Insert(TodolistAppModels.Entities.Task task);
    IActionResult GetTask(int taskId);
}