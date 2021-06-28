
using MQuince.Entities.Drug;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetAll();
    }
}
