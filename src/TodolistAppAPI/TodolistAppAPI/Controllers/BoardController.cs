using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _repository;
        private readonly IListRepository _listRepository;

        public BoardController(IBoardRepository repository, IListRepository listRepository) 
        {
            _repository = repository;
            _listRepository = listRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard(Board board)
        {
            var result = await _repository.Insert(board);

            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            await _listRepository.InsertDefultList(result.Id);
                
            return Ok(result.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetBoards() => Ok(await _repository.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id) => Ok(await _repository.GetBoard(id));
    }
}
