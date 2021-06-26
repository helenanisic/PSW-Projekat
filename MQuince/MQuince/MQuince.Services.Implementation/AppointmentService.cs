using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MQuince.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IWorkScheduleRepository _workScheduleRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IWorkScheduleRepository workScheduleRepository)
        {
            _appointmentRepository = appointmentRepository;
            _workScheduleRepository = workScheduleRepository;
        }

        public Guid Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId)
        {
            return _appointmentRepository.GetAllAppointmentsByPatientId(patientId);
        }

        public IEnumerable<WorkSchedule> findWorkScheduleForDoctorAndTimeRange(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId)
        {
            IEnumerable<WorkSchedule> workSchedules = _workScheduleRepository.FindWorkScheduleForDoctorInDateRange(startDate, endDate, DoctorId);
            List<WorkSchedule> okTime = new List<WorkSchedule>();
            foreach (WorkSchedule w in workSchedules)
            {
                if (w.EndTime < startTime || w.StartTime > endTime)
                    continue;
                else
                {
                    okTime.Add(w);
                }
            }

            return okTime;
        }

        public AppointmentDTO createNewAppointmentDTO(DateTime date, int startTime, Guid doctorId)
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                Date = date,
                StartTime = startTime,
                DoctorId = doctorId
            };
            return appointmentDTO;
        }


        public AppointmentDTO findFreeAppointment(IEnumerable<WorkSchedule> workSchedules, IEnumerable<Appointment> appointments, int startTime, int endTime, bool doctorPriority)
        {

            foreach (WorkSchedule workSchedule in workSchedules)
            {   
                
                int start = workSchedule.StartTime > startTime ?  workSchedule.StartTime :  startTime;
                int end = workSchedule.EndTime < endTime ?  workSchedule.EndTime : endTime;
                if (doctorPriority == true)
                {
                    start = workSchedule.StartTime;
                    end = workSchedule.EndTime;
                }
                for (int i = start; i < end; i++)
                {
                    if (!appointments.Safe().Any())
                        return createNewAppointmentDTO(workSchedule.Date, i, workSchedule.Doctor.Id);
                    

                    foreach (Appointment appointment in appointments)
                    {
                        if (appointment.StartTime == i)
                        {
                            continue;
                        }
                        else
                        {
                            return createNewAppointmentDTO(workSchedule.Date, i, workSchedule.Doctor.Id);
                        }
                    }
                }


            }
            return null;
        }

        public AppointmentDTO findAppointmentDoctorPriority(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId)
        {
            IEnumerable<WorkSchedule>  workSchedules = _workScheduleRepository.FindWorkScheduleForDoctorInDateRange(startDate.AddDays(-7), endDate.AddDays(7), DoctorId);
            AppointmentDTO recommendAppointment = new AppointmentDTO();
            if (workSchedules.Safe().Any())
            {
                IEnumerable<Appointment>  appointments = _appointmentRepository.GetBookedAppointmentsForDoctorInDateRange(startDate.AddDays(-7), endDate.AddDays(7), DoctorId);
                return recommendAppointment = findFreeAppointment(workSchedules, appointments, startTime, endTime, true);
            }
            return null;
        }

        public AppointmentDTO findAppointmentTimePriority(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid specializationId)
        {
            IEnumerable<WorkSchedule>  workSchedules = _workScheduleRepository.FindWorkScheduleForAllDoctorsInDateRange(startDate, endDate, specializationId);
            AppointmentDTO recommendAppointment = new AppointmentDTO();
            if (workSchedules.Safe().Any())
            {
                IEnumerable<Appointment>  appointments = _appointmentRepository.GetAppointmentsAnyDoctor(startDate, endDate);
                return recommendAppointment = findFreeAppointment(workSchedules, appointments, startTime, endTime, false);
            }
            return null;
        }

        public AppointmentDTO findPerfectAppointment(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId)
        {
            IEnumerable<WorkSchedule> workSchedules = findWorkScheduleForDoctorAndTimeRange(startDate, endDate, startTime, endTime, DoctorId);
            AppointmentDTO recommendAppointment = new AppointmentDTO();
            if (workSchedules.Safe().Any())
            {
                IEnumerable<Appointment> appointments = _appointmentRepository.GetBookedAppointmentsForDoctorInDateRange(startDate, endDate, DoctorId);
                return recommendAppointment = findFreeAppointment(workSchedules, appointments, startTime, endTime, false);
            }
            return null;
        }

        public AppointmentDTO findAppointmentByPriority(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId, AppointmentPriority appointmentPriority, Guid specializationId)
        {
            AppointmentDTO recommendAppointment = new AppointmentDTO();
            if (appointmentPriority == AppointmentPriority.DoctorPriority)
                recommendAppointment = findAppointmentDoctorPriority(startDate, endDate, startTime, endTime, DoctorId);          
            if(appointmentPriority == AppointmentPriority.DatePriority)
                recommendAppointment = findAppointmentTimePriority(startDate, endDate, startTime, endTime, specializationId);
            return recommendAppointment;
        }
        public AppointmentDTO RecommendAppointment(DateTime startDate, DateTime endDate, int startTime, int endTime, Guid DoctorId, AppointmentPriority appointmentPriority, Guid specializationId)
        {
            AppointmentDTO recommendAppointment = findPerfectAppointment(startDate, endDate, startTime, endTime, DoctorId);
            if (recommendAppointment == null)
                recommendAppointment = findAppointmentByPriority(startDate, endDate, startTime, endTime, DoctorId, appointmentPriority, specializationId);
            return recommendAppointment;
        }
    }
}
