using Microsoft.AspNetCore.Authentication;
using Moq;
using MQuince.Entities.Authentication;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class Login
    {
        string secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        [Fact]
        public void user_login_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "jelena145@gmail.com",
                Password = "Jelena123"
            };
            Patient patient = CreatePatient();
            var stubRepository = new Mock<IUserRepository>();
            stubRepository.Setup(p => p.AuthenticateUser(user)).Returns(patient);
            UserService userService = new UserService(stubRepository.Object, secret);

            var result = userService.Authenticate(user);

            Assert.NotNull(result);
            Assert.Equal(patient.Id, result.Id);
            Assert.NotNull(result.Token);
        }

        [Fact]
        public void user_login_fail()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "jelena145@gmail.com",
                Password = "Jelena12"
            };
            Patient patient = CreatePatient();
            var stubRepository = new Mock<IUserRepository>();
            stubRepository.Setup(p => p.AuthenticateUser(user));
            UserService userService = new UserService(stubRepository.Object, secret);

            AuthenticateResponse  result = userService.Authenticate(user);

            Assert.Null(result);
        }

        public Patient CreatePatient()
        {
            Patient patient = new Patient
            {
                Id = new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e"),
                Jmbg = "1234567891234",
                BirthDate = new DateTime(2021, 1, 1),
                Gender = Enums.Gender.Female,
                Telephone = "245879",
                Lbo = "123456789",
                Name = "Jelena",
                Surname = "Milosevic",
                Email = "jelena145@gmail.com",
                Password = "Jelena123",
                ChosenDoctorId = new Guid("2270bae8-9f26-4ea5-b10d-0ce11ead067e"),
                ResidenceId = new Guid("d18cb40c-4f01-4dae-9214-1f87330d5a3d")
            };

            return patient;
        }
    }
}
