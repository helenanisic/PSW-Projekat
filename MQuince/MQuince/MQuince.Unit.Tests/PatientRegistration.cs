using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Implementation;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class PatientRegistration
    {
        [Fact]
        public void create_patient_success()
        {
            var stubRepository = new Mock<IPatientRepository>();
            PatientService service = new PatientService(stubRepository.Object);
            PatientDTO patient = new PatientDTO() { };
            Guid id = service.Create(patient);
            Assert.NotEqual(Guid.Empty,id);
        }
    }
}
