
using MQuince.Entities.Drug;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }
    }
}
