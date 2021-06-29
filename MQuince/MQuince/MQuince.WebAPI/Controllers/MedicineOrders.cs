using MQuince.Services.Contracts.DTO.Drug;
using System.Collections.Generic;

namespace MQuince.WebAPI.Controllers
{
    public class MedicineOrders
    {
        public List<MedicineOrderDTO> orders { get; set; }
    }
}