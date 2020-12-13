using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiToDo.Mappers;
using WebApiToDo.Models;
using WebApiToDo.ModelsDTO;
using WebApiToDo.Repositories.Interfaces;
using WebApiToDo.Services;
using Xunit;

namespace WebApiToDo.Test
{
    public class ToDoTest
    {
        private readonly Mock<IToDoRepository> _toDoRepositoryMock;
        public ToDoTest()
        {
            _toDoRepositoryMock = new Mock<IToDoRepository>();
        }
        [Fact]
        public void GetAllAsync_SimpleList()
        {
            //Arrange 
            _toDoRepositoryMock.Setup(repo => repo.ListAllAsync()).Returns(Task.FromResult(TestToDoModelList()));

            var mapper = MockMapper();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            //Act 
            var allItemList = toDoService.GetAllAsync();

            //Assert  
            Assert.NotNull(allItemList);
            Assert.True(allItemList.Result.Count == 2);
            Assert.IsType<List<ToDoDTO>>(allItemList.Result);
        }
        [Fact]
        public void GetAllItemsFilterAsync_SimpleListWithFalseFilter()
        {
            //Arrange 
            var expectedValue = new List<ToDoModel>()
            {
                new ToDoModel()
                {
                Id = 1,
                Title = "New Button",
                Description = "Create new button",
                IsCompleted = 0
                }
            };
            _toDoRepositoryMock.Setup(repo => repo.ListAllItemsFilterAsync(It.IsAny<int>())).Returns(Task.FromResult(expectedValue));

            var mapper = MockMapper();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            //Act 
            var allItemList = toDoService.GetAllItemsFilterAsync(false);

            //Assert  
            Assert.NotNull(allItemList);
            Assert.True(allItemList.Result.Count == 1);
            Assert.IsType<List<ToDoDTO>>(allItemList.Result);
        }

        [Fact]
        public void DeleteItemAsync_ExistItem()
        {
            //Arrange 
            _toDoRepositoryMock
                .Setup(repo =>
                repo.DeleteItemAsync(It.IsAny<ToDoModel>()));

            _toDoRepositoryMock
                .Setup(repo =>
                repo.FindItemByIDAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(TestToDoModel()));
            var mapper = MockMapper();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            //Act 
            var allItemList = toDoService.DeleteItemAsync(1);

            //Assert  
            Assert.NotNull(allItemList);
            Assert.True(allItemList.Result);
        }
        [Fact]
        public void DeleteItemAsync_NotExistItem()
        {
            //Arrange 
            _toDoRepositoryMock
                .Setup(repo =>
                repo.DeleteItemAsync(It.IsAny<ToDoModel>()));
            var mapper = MockMapper();

            var toDoService = new ToDoService(_toDoRepositoryMock.Object, mapper);

            //Act 
            var allItemList = toDoService.DeleteItemAsync(1);

            //Assert  
            Assert.False(allItemList.Result);
        }
        private IMapper MockMapper()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            return new Mapper(configuration);
        }
        private List<ToDoModel> TestToDoModelList()
        {
            var todoModel = new List<ToDoModel>();
            todoModel.Add(new ToDoModel()
            {
                Id = 1,
                Title = "New Button",
                Description = "Create new button",
                IsCompleted = 0
            });
            todoModel.Add(new ToDoModel()
            {
                Id = 2,
                Title = "test",
                Description = ":hahahah",
                IsCompleted = 0
            });

            return todoModel;
        }
        private ToDoModel TestToDoModel()
        {
            return  new ToDoModel()
            {
                Id = 1,
                Title = "New Button",
                Description = "Create new button",
                IsCompleted = 0
            };
        }
    }
}
