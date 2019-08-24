using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EasyFlights.API.Services;
using EasyFlights.Models;
using EasyFlights.API.Controllers;
using EasyFlights.UnitTest.API_FakeServices;

namespace EasyFlights.UnitTest
{
    [TestClass]
    public class DataService_Test_UserRepository
    {
        private readonly IDataService _dataService;
        private readonly UsersController _controller;
        private readonly UserContext _context;

        public DataService_Test_UserRepository()
        {
            _dataService = new DataServiceFake();
            //_context = new UserContextFake();
            _controller = new UsersController(_context,_dataService);
        }
        
    }
}
