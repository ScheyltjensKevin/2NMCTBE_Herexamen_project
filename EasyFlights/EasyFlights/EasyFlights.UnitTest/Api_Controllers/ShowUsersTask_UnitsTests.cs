using EasyFlights.API.Repositories;
using EasyFlights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Api_Controllers.UnitTest
{
    [TestClass]
    public class ShowUsersTask_UnitsTests
    {

        private Task<IEnumerable<User>> users = Task.FromResult(new List<User>() as IEnumerable<User>);

        [TestInitialize]
        public async Task<IEnumerable<User>> GetAllFakeUsersAsync()
        {
            List<User> lst = new List<User>();
            for (int i = 0; i < 5; i++)
            {

            };
            return lst;
        }




        //[TestMethod]
        //public async Task TaskAPICtrlAsync_GET_ReturnsUsers()
        //{
        //    //             Arrange(Mock op de interface - anders not supported exception)
        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(repo => repo.Get()).Returns(users);
        //    API.Controllers.UserController controllerAPI = new API.Controllers.UserController(mockRepo.Object, null);
        //    // Act met await
        //    var actionResult = await controllerAPI.Get();
        //    var okResult = actionResult as OkObjectResult;
        //    IEnumerable<ToDoTask_DTO> Tasks = okResult.Value as IEnumerable<ToDoTask_DTO>;
        //    // Assert:         Controleer altijd  null + datatypes + statuscode + inhoud
        //    Assert.IsNotNull(okResult);
        //    Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        //    Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<ToDoTask_DTO>));
        //    Assert.IsTrue(Tasks.Count() == 10);
        //    Assert.AreEqual(200, okResult.StatusCode);
        //}
    }
}

