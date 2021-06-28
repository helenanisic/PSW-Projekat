using CSharpFunctionalExtensions;
using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IPrescriptionService
    {
        Result<string> Create(Prescription entity);
    }
}
