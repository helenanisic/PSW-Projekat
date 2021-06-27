using Moq;
using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Implementation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MQuince.Unit.Tests
{
    public class BookAppointment
    {
        [Fact]
        public void book_appointment_doctor_and_time_all_free_success()
        {
            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor = new Doctor()
            {
                SpecializationId = general.Id
            };
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedules = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor,
                StartTime = 10,
                EndTime = 15,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedules.Add(workSchedule1);
            workSchedules.Add(workSchedule2);

            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor.Id));
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor.Id)).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor.Id, Enums.AppointmentPriority.DoctorPriority, general.Id);
            appointmentDTO.Date.ShouldBe(new DateTime(2021, 08, 17));
            appointmentDTO.StartTime.ShouldBe(10);
        }

        [Fact]
        public void book_appointment_doctor_and_time_success()
        {
            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor = new Doctor()
            {
                SpecializationId = general.Id
            };
            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedules = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor,
                StartTime = 10,
                EndTime = 15,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedules.Add(workSchedule1);
            workSchedules.Add(workSchedule2);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor.Id)).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor.Id, Enums.AppointmentPriority.DoctorPriority, general.Id);
            appointmentDTO.Date.ShouldBe(new DateTime(2021, 08, 17));
            appointmentDTO.StartTime.ShouldBe(11);
        }

        [Fact]
        public void book_appointment_time_priority_success()
        {

            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor1 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Doctor doctor2 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedulesForDoctor = new List<WorkSchedule>();
            List<WorkSchedule> workSchedules = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 19),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule3 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor2,
                StartTime = 10,
                EndTime = 15,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule4 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor2,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedulesForDoctor.Add(workSchedule1);
            workSchedulesForDoctor.Add(workSchedule2);
            workSchedules.Add(workSchedule3);
            workSchedules.Add(workSchedule4);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor1,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(workSchedulesForDoctor);
            stubRepository2.Setup(p => p.FindWorkScheduleForAllDoctorsInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), general.Id)).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor1.Id, Enums.AppointmentPriority.DatePriority, general.Id);
            appointmentDTO.Date.ShouldBe(new DateTime(2021, 08, 18));
            appointmentDTO.StartTime.ShouldBe(10);
            appointmentDTO.DoctorId.ShouldBe(doctor2.Id);

        }

        [Fact]
        public void book_appointment_time_priority_specialist_success()
        {

            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Specialization derm = new Specialization()
            {
                Name = "Dermatologist"
            };
            Doctor doctor1 = new Doctor()
            {
                SpecializationId = derm.Id
            };
            Doctor doctor2 = new Doctor()
            {
                SpecializationId = derm.Id
            };
            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedulesForDoctor = new List<WorkSchedule>();
            List<WorkSchedule> workSchedules = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 19),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule3 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor2,
                StartTime = 10,
                EndTime = 15,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule4 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor2,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedulesForDoctor.Add(workSchedule1);
            workSchedulesForDoctor.Add(workSchedule2);
            workSchedules.Add(workSchedule3);
            workSchedules.Add(workSchedule4);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor1,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(workSchedulesForDoctor);
            stubRepository2.Setup(p => p.FindWorkScheduleForAllDoctorsInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), derm.Id)).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor1.Id, Enums.AppointmentPriority.DatePriority, derm.Id);
            appointmentDTO.Date.ShouldBe(new DateTime(2021, 08, 18));
            appointmentDTO.StartTime.ShouldBe(10);
            appointmentDTO.DoctorId.ShouldBe(doctor2.Id);
        }

        [Fact]
        public void book_appointment_time_priority_fail()
        {

            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor1 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Doctor doctor2 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedulesForDoctor = new List<WorkSchedule>();
            List<WorkSchedule> workSchedules = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 19),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule3 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor2,
                StartTime = 20,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule4 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor2,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedulesForDoctor.Add(workSchedule1);
            workSchedulesForDoctor.Add(workSchedule2);
            workSchedules.Add(workSchedule3);
            workSchedules.Add(workSchedule4);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor1,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(workSchedulesForDoctor);
            stubRepository2.Setup(p => p.FindWorkScheduleForAllDoctorsInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), general.Id)).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor1.Id, Enums.AppointmentPriority.DatePriority, general.Id);
            Assert.Null(appointmentDTO);

        }

        [Fact]
        public void book_appointment_doctor_priority_success()
        {

            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor1 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Doctor doctor2 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedulesForDoctor = new List<WorkSchedule>();
            List<WorkSchedule> workSchedulesForDoctor7 = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 15),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 22),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule3 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 23,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule4 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedulesForDoctor7.Add(workSchedule1);
            workSchedulesForDoctor7.Add(workSchedule2);
            workSchedulesForDoctor.Add(workSchedule3);
            workSchedulesForDoctor.Add(workSchedule4);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 15),
                Doctor = doctor1,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(workSchedulesForDoctor);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 10), new DateTime(2021, 08, 27), doctor1.Id)).Returns(workSchedulesForDoctor7);
            //stubRepository2.Setup(p => p.FindWorkScheduleForAllDoctorsInDateRange(new DateTime(20212120, 08, 17), new DateTime(2021, 08, 20))).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor1.Id, Enums.AppointmentPriority.DoctorPriority, general.Id);
            appointmentDTO.Date.ShouldBe(new DateTime(2021, 08, 15));
            appointmentDTO.StartTime.ShouldBe(19);
            appointmentDTO.DoctorId.ShouldBe(doctor1.Id);

        }

        [Fact]
        public void book_appointment_doctor_priority_fail()
        {
            Specialization general = new Specialization()
            {
                Name = "General"
            };
            Doctor doctor1 = new Doctor()
            {
                SpecializationId = general.Id
            };
            Doctor doctor2 = new Doctor()
            {
                SpecializationId = general.Id
            };

            Patient patient = new Patient();
            var stubRepository1 = new Mock<IAppointmentRepository>();
            var stubRepository2 = new Mock<IWorkScheduleRepository>();
            List<WorkSchedule> workSchedulesForDoctor = new List<WorkSchedule>();
            List<WorkSchedule> workSchedulesForDoctor7 = new List<WorkSchedule>();
            WorkSchedule workSchedule1 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 15),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule2 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 22),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule3 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 17),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 23,
                Id = Guid.NewGuid()
            };

            WorkSchedule workSchedule4 = new WorkSchedule()
            {
                Date = new DateTime(2021, 08, 18),
                Doctor = doctor1,
                StartTime = 19,
                EndTime = 22,
                Id = Guid.NewGuid()
            };

            workSchedulesForDoctor7.Add(workSchedule1);
            workSchedulesForDoctor7.Add(workSchedule2);
            workSchedulesForDoctor.Add(workSchedule3);
            workSchedulesForDoctor.Add(workSchedule4);

            List<Appointment> appointments = new List<Appointment>();
            Appointment app1 = new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2021, 08, 15),
                Doctor = doctor1,
                StartTime = 10,
                Status = Enums.AppointmentStatus.Pending,
                Patient = patient,
                Type = Enums.TreatmentType.Examination
            };

            appointments.Add(app1);
            stubRepository1.Setup(p => p.GetBookedAppointmentsForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(appointments);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), doctor1.Id)).Returns(workSchedulesForDoctor);
            stubRepository2.Setup(p => p.FindWorkScheduleForDoctorInDateRange(new DateTime(2021, 08, 10), new DateTime(2021, 08, 27), doctor1.Id));
            //stubRepository2.Setup(p => p.FindWorkScheduleForAllDoctorsInDateRange(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20))).Returns(workSchedules);
            AppointmentService appointmentService = new AppointmentService(stubRepository1.Object, stubRepository2.Object);
            AppointmentDTO appointmentDTO = appointmentService.RecommendAppointment(new DateTime(2021, 08, 17), new DateTime(2021, 08, 20), 8, 18, doctor1.Id, Enums.AppointmentPriority.DoctorPriority, general.Id);
            Assert.Null(appointmentDTO);

        }

        
    }
}
 