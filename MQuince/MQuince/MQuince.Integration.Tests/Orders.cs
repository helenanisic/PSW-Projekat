using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Entities.Authentication;
using MQuince.Services.Contracts.DTO.Drug;
using MQuince.Services.Contracts.Interfaces;
using MQuince.WebAPI;
using MQuince.WebAPI.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Integration.Tests
{
    public class Orders : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public IUserService _userService;
        public Orders(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
            _userService = (IUserService)factory.Services.GetService(typeof(IUserService));
        }

        [Fact]
        public async Task create_order_success()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "zoran@gmail.com",
                Password = "Zoran123"
            };
            string Datum = "2021-07-11";
            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Order?deadline=" + Datum);
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseAsConcreteType = JsonConvert.DeserializeObject<int>(responseAsString);
            MedicineOrderDTO medOrderDTO = new MedicineOrderDTO()
            {
                errandId = responseAsConcreteType,
                id = 2,
                quantity = 8,
                name = "Metafex"
            };
            MedicineOrders orders = new MedicineOrders()
            {
                orders = new List<MedicineOrderDTO>()
            };
            orders.orders.Add(medOrderDTO);
            HttpResponseMessage response1 = await Client.PostAsync("/api/Order/medications", Helpers.GetByteArrayContent(orders));
            Assert.Equal(StatusCodes.Status200OK, (double)response1.StatusCode);
        }

        [Fact]
        public async Task create_order_wrong_role_fail()
        {
            AuthenticateRequest user = new AuthenticateRequest
            {
                Email = "helena@gmail.com",
                Password = "Helena123"
            };
            string Datum = "2021-07-11";
            var result = _userService.Authenticate(user);
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + result.Value.Token);
            HttpResponseMessage response = await Client.GetAsync("/api/Order?deadline=" + Datum);
            Assert.Equal(StatusCodes.Status403Forbidden, (double)response.StatusCode);
        }
    }
}
