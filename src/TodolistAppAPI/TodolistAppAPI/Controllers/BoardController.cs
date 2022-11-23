using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Interfaces;
using TodolistAppDomain.Repositories;
using TodolistAppModels.Entities;
using Task = System.Threading.Tasks.Task;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _repository;

        public BoardController(IBoardRepository repository) 
        {
                _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard(Board board)
        {
            var result = await _repository.Insert(board);

            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            return Ok(result.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetBoards() => Ok(await _repository.GetAll());
    }
}
