using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DbContextOptions _dbContext;

        public AppointmentRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Appointment> GetAllAppointmentsByPatientId(Guid patientId)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return AppointmentMapper.MapAppointmentPersistenceCollectionToAppointmentEntityCollection(context.Appointments.Include("Doctor").Include("Patient").Where(a => a.PatientId.Equals(patientId)).ToList());
        }

        public Guid Create(Appointment appointment)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            context.Appointments.Add(AppointmentMapper.MapAppointmentEntityToAppointmentPersistence(appointment));
            return context.SaveChanges() > 0 ? appointment.Id : Guid.Empty;
        }

        public IEnumerable<Appointment> GetBookedAppointmentsForDoctorInDateRange(DateTime startDate, DateTime endDate,  Guid DoctorId)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return AppointmentMapper.MapAppointmentPersistenceCollectionToAppointmentEntityCollection(context.Appointments.Include("Doctor").Where(a => a.DoctorId.Equals(DoctorId) & a.Date.Date >= startDate.Date & a.Date.Date <= endDate.Date ).ToList());
        }

        public IEnumerable<Appointment> GetAppointmentsAnyDoctor(DateTime startDate, DateTime endDate)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return AppointmentMapper.MapAppointmentPersistenceCollectionToAppointmentEntityCollection(context.Appointments.Include("Doctor").Where(a => a.Date.Date >= startDate.Date & a.Date.Date <= endDate.Date).ToList());
        }

        public bool Delete(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                var appointment = _context.Appointments.SingleOrDefault(c => c.Id.Equals(id));
                if (appointment == null)
                    return false;
                _context.Appointments.Remove(appointment);
                return _context.SaveChanges() > 0 ? true : false;
            }
        }
        public Appointment GetById(Guid id)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return AppointmentMapper.MapAppointmentPersistenceToAppointmentEntity(_context.Appointments.Include("Doctor").Include("Patient").SingleOrDefault(d => d.Id == id));
        }
    }
}
