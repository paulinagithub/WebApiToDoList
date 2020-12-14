using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiToDo.Mappers;
using WebApiToDo.Models;
using WebApiToDo.ModelsDTO;
using WebApiToDo.Repositories.Interfaces;
using WebApiToDo.Services;
using Xunit;

namespace WebApiToDoTests
{
    public class ToDoTests
    {
        private readonly Mock<IToDoRepository> _toDoRepositoryMock;

        private static readonly ToDoModel _toDoExample = new ToDoModel 
        {
            Id = 1,
            Title = "New Button",
            Description = "Create new button",
            IsCompleted = 0
        };

        private static readonly ToDoDTO _toDoDTOExample = new ToDoDTO
        {
            Title = "New Button",
            Description = "Create new button",
            IsCompleted = true
        };

        private static readonly List<ToDoModel> _toDosExample = new List<ToDoModel>
        {
            new ToDoModel { Id = 1, Title = "New Button", Description = "Create new button", IsCompleted = 0},
            new ToDoModel { Id = 1, Title = "New check list", Description = "Create new check list", IsCompleted = 0}
        };     

        public ToDoTests()
        {
            _toDoRepositoryMock = new Mock<IToDoRepository>();
        }

        [Fact]
        public void GetAllItemsWithTwoElements()
        {
            // Arrange 
            _toDoRepositoryMock
                .Setup(repo => repo.GetAllItemsAsync())
                .Returns(Task.FromResult(_toDosExample));

            var mapper = GetMapperMock();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            // Act 
            var allItemList = toDoService.GetAllItemsAsync();

            // Assert  
            Assert.Equal(2, allItemList.Result.Count);
        }

        [Fact]
        public void GetAllItemsWithFalseArgument()
        {
            // Arrange 
            var expectedValue = new List<ToDoModel>()
            {
                _toDoExample
            };

            _toDoRepositoryMock
                .Setup(repo => repo.GetAllItemsFilterAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(expectedValue));

            var mapper = GetMapperMock();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            // Act 
            var allItemList = toDoService.GetAllItemsFilterAsync(false);

            // Assert           
            Assert.Equal(1, allItemList.Result.Count);
        }

        [Fact]
        public void DeleteIfItemIsExist()
        {
            // Arrange 
            _toDoRepositoryMock
                .Setup(repo => repo.DeleteItemAsync(It.IsAny<ToDoModel>()));

            _toDoRepositoryMock
                .Setup(repo => repo.FindItemByIDAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(_toDoExample));

            var mapper = GetMapperMock();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            // Act 
            var allItemList = toDoService.DeleteItemAsync(It.IsAny<int>());

            // Assert             
            Assert.True(allItemList.Result);
        }

        [Fact]
        public void DeleteIfItemIsNotExist()
        {
            // Arrange 
            _toDoRepositoryMock
                .Setup(repo => repo.DeleteItemAsync(It.IsAny<ToDoModel>()));

            var mapper = GetMapperMock();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            // Act 
            var allItemList = toDoService.DeleteItemAsync(It.IsAny<int>());

            // Assert  
            Assert.False(allItemList.Result);
        }

        [Fact]
        public async void UpdateItemWithException()
        {
            // Arrange 
            _toDoRepositoryMock
                .Setup(repo => repo.UpdateToDoAsync(It.IsAny<ToDoModel>()))
                .Returns(Task.FromException(new DbUpdateException()));

            var mapper = GetMapperMock();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            // Act 
            Task allItemList() => toDoService.UpdateItemAsync(It.IsAny<int>(), _toDoDTOExample);

            // Assert  
            await Assert.ThrowsAsync<DbUpdateException>(allItemList);
        }

        private IMapper GetMapperMock()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            return new Mapper(configuration);
        }
    }
}
