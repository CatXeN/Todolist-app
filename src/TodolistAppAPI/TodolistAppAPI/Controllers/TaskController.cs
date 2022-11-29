using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations;

namespace TodolistAppAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController: ControllerBase
{
    private readonly ITaskRepository _repository;
    
    public TaskController(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    public async Task<IActionResult> InsertTask(AddTaskInformation addTaskInformation)
    {
        var task = new TodolistAppModels.Entities.Task()
        {
            Name = addTaskInformation.Name,
            Description = addTaskInformation.Description,
            Date = DateTime.Now,
            ListId = addTaskInformation.ListId
        };

        await _repository.Insert(task);
        return Ok();
    }
}