using MQuince.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using Xunit;
using Moq;

namespace MQuince.Integration.Tests
{
    public class Login
    {
        private UserController userController;
        private IUserService userService;
        private IUserRepository userRepository;

        private static ISession MockHttpContext()
        {
            MockHttpSession httpcontext = new MockHttpSession();
            httpcontext.SetString("UserEmail", "unittest@mycompany.com");
            return httpcontext;
        }

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MQuinceDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());


            userRepository = new UserRepository(optionsBuilder);
            using var dataBase = new MQuinceDbContext(optionsBuilder.Options);
            dataBase.Database.EnsureDeleted();
            dataBase.Database.EnsureCreated();

            AddPatientsToDB(dataBase);
        }

        private void AddPatientsToDB(MQuinceDbContext dataBase)
        {
            PatientPersistence patient1 = new PatientPersistence()
            {
                Id = Guid.NewGuid(),
                Email = "email@gmail.com",
                Password = "123"
            };
            PatientPersistence patient2 = new PatientPersistence()
            {
                Id = Guid.NewGuid(),
                Email = "email@hotmail.com",
                Password = "567"
            };
            dataBase.Patients.AddRange(patient1, patient2);
            dataBase.SaveChanges();
        }

        public Login()
        {
            InitDB();
            userService = new UserService(userRepository);
            userController = new UserController(userService);
        }

        [Fact]
        public void user_login_success()
        {
            string Email = "email@gmail.com";
            string Password = "123";
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession["UserId"] = "123";
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            userController.ControllerContext.HttpContext = mockHttpContext.Object;
            
            IActionResult actual = userController.AuthenticateUser(Email, Password);
            var okResult = actual as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}

