using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TodolistAppAPI.Authorization;
using TodolistAppAPI.Controllers;
using TodolistAppDomain.Identity;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations.Boards;
using Xunit;

namespace TodolistAppTest.ControllerTests
{
    public class BoardControllerTest
    {
        private readonly BoardController _controller;
        private readonly Mock<IBoardRepository> _repository;
        private readonly Mock<IListRepository> _listRepository;
        private readonly Mock<IPermissionAccess> _permissionAccess;
        private readonly Mock<IIdentityService> _identityService;

        public BoardControllerTest()
        {
            _repository = new Mock<IBoardRepository>();
            _listRepository = new Mock<IListRepository>();
            _permissionAccess = new Mock<IPermissionAccess>();
            _identityService = new Mock<IIdentityService>();
            _controller = new BoardController(_repository.Object, _listRepository.Object, _permissionAccess.Object, _identityService.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task AddBoard_ModelIsValid_ReturnsObjectResult()
        {
            _repository.Setup(x => x.Insert(It.IsAny<Board>()))
                .ReturnsAsync(new Board() { Id = 2, Name = "TestBoard" });

            var result = await _controller.AddBoard(new AddBoardInformation() { Name = It.IsAny<string>(), UserId = It.IsAny<int>() }) as OkObjectResult;

            if (result != null)
                result.Value.Should().Be(2);
            else
                Assert.True(false, "Object was null");
        }

        [Fact]
        public async System.Threading.Tasks.Task AddBoard_ModelIsValid_ServiceHasBeenCalled()
        {
            _repository.Setup(x => x.Insert(It.IsAny<Board>()))
                .ReturnsAsync(new Board() { Id = 2, Name = "TestBoard" });
            _repository.Setup(x => x.AssignUserToBoard(It.IsAny<UserToBoard>()));
            _listRepository.Setup(x => x.InsertDefaultList(It.IsAny<int>()));

            var result = await _controller.AddBoard(new AddBoardInformation() { Name = It.IsAny<string>(), UserId = It.IsAny<int>() }) as OkObjectResult;

            _repository.Verify(x => x.Insert(It.IsAny<Board>()), Times.Once);
            _repository.Verify(x => x.AssignUserToBoard(It.IsAny<UserToBoard>()));
            _listRepository.Verify(x => x.InsertDefaultList(It.IsAny<int>()));
        }
    }
}
