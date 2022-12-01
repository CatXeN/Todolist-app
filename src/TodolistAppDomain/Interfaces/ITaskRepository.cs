using Microsoft.AspNetCore.Mvc;

namespace TodolistAppDomain.Interfaces;

public interface ITaskRepository
{
    Task<TodolistAppModels.Entities.Task> Insert(TodolistAppModels.Entities.Task task);
    Task Update(TodolistAppModels.Entities.Task task);
    Task<TodolistAppModels.Entities.Task> GetTask(int taskId);
}