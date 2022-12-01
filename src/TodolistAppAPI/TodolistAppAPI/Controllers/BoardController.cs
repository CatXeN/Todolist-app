using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodolistAppAPI.Authorization;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations.Boards;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _repository;
        private readonly IListRepository _listRepository;
        private readonly IPermissionAccess _access;

        public BoardController(IBoardRepository repository, IListRepository listRepository, IPermissionAccess access) 
        {
            _repository = repository;
            _listRepository = listRepository;
            _access = access;
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard(AddBoardInformation board)
        {
            var result = await _repository.Insert(new Board() { Name = board.Name });

            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            await _repository.AssignUserToBoard(new UserToBoard() { BoardId = result.Id, UserId = board.UserId, IsOwner = true });
            await _listRepository.InsertDefaultList(result.Id);               
            return Ok(result.Id);
        }

        [Authorize()]
        [HttpGet]
        public async Task<IActionResult> GetBoards()
        {
            int userId = _access.GetUserId();

            if (userId == 0)
                return BadRequest();

            return Ok(await _repository.GetAll(userId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id) => Ok(await _repository.GetBoard(id));
    }
}
