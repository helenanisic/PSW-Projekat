using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using Xunit;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using MQuince.WebAPI.Controllers;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using MQuince.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace MQuince.Integration.Tests
{
    public class PatientRegistration : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public PatientRegistration(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task register_patient_success()
        {

            PatientDTO patientDTO = new PatientDTO()
            {
       
                 Name = "Andrej",
                 Surname = "Anisic",
                 Telephone = "354354355",
                 Jmbg = "1234567891234",
                 BirthDate = new DateTime(),
                 Email = "andrej123" + RandomNumberGenerator.GetInt32(1,int.MaxValue).ToString() + "@gmail.com",
                 Password = "Andrej123",
                 UserType = Enums.Usertype.Patient,
                 Gender = Enums.Gender.Male,
                 ResidenceId = new Guid("01e84c9b-e188-431e-bea3-6aa15b56e61d"),
                 Lbo = "78645431",
                 ChosenDoctorId = new Guid("fdea1b1d-bafc-4056-b5aa-6bacd468d080"),
                 Banned = false
            };
            HttpResponseMessage response = await Client.PostAsync("/api/Patient", Helpers.GetByteArrayContent(patientDTO));
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.Equal(StatusCodes.Status201Created, (double)response.StatusCode);
        }
    }
}
