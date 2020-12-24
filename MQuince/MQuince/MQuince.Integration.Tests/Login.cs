using MQuince.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MQuince.Integration.Tests
{
    public class Login
    {
        private UserController userController;
        private IUserService userService;
        private IUserRepository userRepository;

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MQuinceDbContext>();
            optionsBuilder.UseInMemoryDatabase("mquince");


            userRepository = new UserRepository(optionsBuilder);
            using (var dataBase = new MQuinceDbContext(optionsBuilder.Options))
            {

                if (dataBase == null)
                {
                    Console.WriteLine("Test");
                }

                dataBase.Database.EnsureDeleted();
                dataBase.Database.EnsureCreated();

                
            }
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


            IActionResult actual = userController.AuthenticateUser(Email, Password);
            var okResult = actual as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}

