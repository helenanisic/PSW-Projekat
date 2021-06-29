using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Drug;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateErrand(string deadline)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:9001");
            var client = new ErrandService.ErrandServiceClient(channel);
            var response = await client.newErrandAsync(new ErrandRequest { Deadline = deadline });
            if (response.Id == -1)
                return BadRequest("Greska!");
            return Ok(response.Id);
        }

        [HttpPost("medications")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Medications(MedicineOrders orders)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:9001");
            var client = new ErrandService.ErrandServiceClient(channel);
            ErrandMedicationRequest errandMedicationRequest = new ErrandMedicationRequest();
            foreach(MedicineOrderDTO order in orders.orders)
            errandMedicationRequest.ErrandMedications.Add(new ErrandMedication() { ErrandId = order.errandId, Id = order.id, Name = order.name, Quantity = order.quantity});
            var response = await client.errandMedicationAsync(errandMedicationRequest);
            return Ok(response.Response);
        }

        
    }
}