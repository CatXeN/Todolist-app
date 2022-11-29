namespace TodolistAppDomain.Interfaces;

public interface ITaskRepository
{
    Task<TodolistAppModels.Entities.Task> Insert(TodolistAppModels.Entities.Task task);
}