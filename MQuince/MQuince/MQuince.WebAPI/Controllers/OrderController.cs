using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateErrand()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:9001");
            var client = new ErrandService.ErrandServiceClient(channel);
            var response = await client.newErrandAsync(new ErrandRequest { Deadline = "2021-08-21" });
            return Ok(response.Id);
        }

        [HttpGet("medications")]
        public async Task<IActionResult> Medications()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:9001");
            var client = new ErrandService.ErrandServiceClient(channel);
            ErrandMedicationRequest errandMedicationRequest = new ErrandMedicationRequest();
            errandMedicationRequest.ErrandMedications.Add(new ErrandMedication() { ErrandId = 1, Id = 2, Name = "Metafex", Quantity = 1});
            var response = await client.errandMedicationAsync(errandMedicationRequest);
            return Ok(response.Response);
        }
    }
}