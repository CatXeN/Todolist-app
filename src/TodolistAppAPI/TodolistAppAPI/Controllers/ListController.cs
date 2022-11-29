using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Interfaces;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListRepository _repository;

        public ListController(IListRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetLists(int boardId) => Ok(await _repository.GetFullList(boardId));
    }
}
