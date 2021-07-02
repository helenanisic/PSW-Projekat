using Moq;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Unit.Tests
{
    public class BanPatient
    {
        private readonly Patient patient;
        private readonly Patient patientBanned;

        public BanPatient()
        {
            patient = new Patient()
            {
                Id = new Guid("9f09782a-c13b-4769-8689-50d784dcd4a8"),
                UserType = Enums.Usertype.Patient,
                Name = "Milan",
                Surname = "Milanovic",
                Email = "milan@gmail.com",
                Password = "Milan123",
                Banned = false,
                ResidenceId = Guid.NewGuid(),
                ChosenDoctorId = Guid.NewGuid()
            };
            patientBanned = patient;
            patientBanned.Banned = true;
        }

        [Fact]
        public void ban_patient_success()
        {
            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(p => p.GetById(patient.Id)).Returns(patient);
            stubRepository.Setup(p => p.BanPatient(patientBanned)).Returns(patientBanned);
            PatientService patientService = new PatientService(stubRepository.Object);

            Patient patient2 = patientService.BanPatient(new Guid("9f09782a-c13b-4769-8689-50d784dcd4a8"));

            Assert.NotNull(patient2);
            Assert.True(patient2.Banned);
        }



        [Fact]
        public void ban_patient_user_not_found_fail()
        {
            var stubRepository = new Mock<IPatientRepository>();
            stubRepository.Setup(p => p.GetById(patient.Id));
            PatientService patientService = new PatientService(stubRepository.Object);

            Patient patient2 = patientService.BanPatient(new Guid("9f09782a-c13b-4769-8689-50d784dcd4a8"));

            Assert.Null(patient2);
        }
    }
}
