using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodolistAppAPI.Authorization;
using TodolistAppDomain.Exceptions;
using TodolistAppDomain.Identity;
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
        private readonly IIdentityService _identityService;

        public BoardController(IBoardRepository repository, IListRepository listRepository, IPermissionAccess access, IIdentityService identityService) 
        {
            _repository = repository;
            _listRepository = listRepository;
            _access = access;
            _identityService = identityService;
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

        [HttpGet("GetAssignedUser/{boardId}")]
        public async Task<IActionResult> GetAssignedUser(int boardId) => Ok(await _repository.GetAssignedUserToBoard(boardId));

        [HttpPost("assignUserToBoard")]
        public async Task<IActionResult> AssignUserToBoard(AssignUserToBoardInformation assignUserToBoardInformation)
        {
            try
            {
                var user = await _identityService.SerachUserByEmail(assignUserToBoardInformation.Email);

                var assignUserToBoard = new UserToBoard()
                {
                    BoardId = assignUserToBoardInformation.BoardId,
                    UserId = user,
                    IsOwner = false
                };

                await _repository.AssignUserToBoard(assignUserToBoard);

                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize()]
        [HttpGet("isOwner/{id}")]
        public async Task<IActionResult> IsOwner(int id)
        {
            var userId = _access.GetUserId();

            return Ok(await _repository.IsOwner(id, userId));
        }
    }
}
