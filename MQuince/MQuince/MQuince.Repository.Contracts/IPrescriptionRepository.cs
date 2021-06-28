using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IPrescriptionRepository
    {
        String Create(Prescription entity);
    }
}
