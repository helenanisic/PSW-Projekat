using Moq;
using MQuince.Entities;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class PatientRegistration
    {
        [Fact]
        public void register_patient_with_unique_email_success()
        {
            Patient patient = CreatePatient();
            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(p => p.IsEmailUnique(patient.Email)).Returns(true);
            stubRepository.Setup(p => p.Create(patient)).Returns(new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e"));
            PatientService patientService = new PatientService(stubRepository.Object);

            var result = patientService.Create(patient);

            Assert.True(result.IsSuccess);
            Assert.Equal(new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e"), result.Value);
        }

        [Fact]
        public void register_patient_not_unique_email_failure()
        {

            Patient patient = CreatePatient();
            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(p => p.IsEmailUnique(patient.Email)).Returns(false);
            stubRepository.Setup(p => p.Create(patient)).Returns(new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e"));
            PatientService patientService = new PatientService(stubRepository.Object);

            var result = patientService.Create(patient);

            Assert.True(result.IsFailure);
        }
        public Patient CreatePatient()
        {
            Patient patient = new Patient
            {
                Id = new Guid("2270bae8-9f26-4ea5-b20d-0ce11ead067e"),
                Jmbg = "1234567891234",
                BirthDate = new DateTime(2021, 1, 1),
                Gender = Enums.Gender.Female,
                Telephone = "245879",
                Lbo = "123456789",
                Name = "Jelena",
                Surname = "Milosevic",
                Email = "jelena145@gmail.com",
                Password = "Jelena123",
                ChosenDoctorId = new Guid("2270bae8-9f26-4ea5-b10d-0ce11ead067e"),
                ResidenceId = new Guid("d18cb40c-4f01-4dae-9214-1f87330d5a3d")
            };

            return patient;
        }
    }


}
