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
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.WebAPI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MQuince.Integration.Tests
{
    public class Login : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public Login(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task user_login_success()
        {
            String email = "helena@gmail.com";
            String password = "Helena123";
            HttpResponseMessage response = await Client.GetAsync("/api/User?email=" + email + "&password=" + password);
            Assert.Equal(StatusCodes.Status200OK, (double)response.StatusCode);
        }
    }
}

