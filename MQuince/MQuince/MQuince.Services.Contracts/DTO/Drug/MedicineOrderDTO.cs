using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Drug
{
    [Serializable]
    public class MedicineOrderDTO
    {
        public int id { get; set; }
        public int errandId { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
    }
}
