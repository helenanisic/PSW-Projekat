using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Entities;
using MQuince.Entities.Users;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class PatientMapper
    {
        public static Patient MapPatientPersistenceToPatientEntity(PatientPersistence patient)
        {
            return patient == null ? null : new Patient(patient.Id, patient.UserType, patient.Name, patient.Surname, patient.Email, patient.Password, patient.Jmbg, patient.BirthDate, patient.Gender, patient.Telephone, 
                patient.ResidenceId, patient.ChosenDoctorId, patient.Lbo, patient.MissedAppointments, patient.Banned);
        }

        public static IEnumerable<Patient> MapPatientPersistenceCollectionToPatientEntityCollection(
            IEnumerable<PatientPersistence> patients)
        {
            return patients.Select(c => MapPatientPersistenceToPatientEntity(c));
        }

        public static PatientPersistence MapPatientEntityToPatientPersistence(Patient patient)
        {
            if (patient == null) return null;

            var retVal = new PatientPersistence()
            {
                Id = patient.Id,
                UserType = patient.UserType,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Password = patient.Password,
                Jmbg = patient.Jmbg,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                Telephone = patient.Telephone,
                ResidenceId = patient.ResidenceId,
                ChosenDoctorId = patient.ChosenDoctorId,
                Lbo = patient.Lbo,
                MissedAppointments = patient.MissedAppointments,
                Banned = patient.Banned
            };
            return retVal;
        }

        public static IEnumerable<PatientPersistence> MapPatientEntityCollectionToPatientPersistenceCollection(
            IEnumerable<Patient> patients)
        {
            return patients.Select(c => MapPatientEntityToPatientPersistence(c));
        }
    }
}
