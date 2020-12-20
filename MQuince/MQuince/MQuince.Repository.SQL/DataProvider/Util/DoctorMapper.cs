using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class DoctorMapper
    {
        public static Doctor MapDoctorPersistenceToDoctorEntity(DoctorPersistence doctor)
        {
            return doctor == null
                ? null
                : new Doctor(doctor.Id, doctor.UserType, doctor.Name, doctor.Surname, doctor.Email, doctor.Password,
                    SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(doctor.Specialization));
        }

        public static IEnumerable<Doctor> MapDoctorPersistenceCollectionToDoctorEntityCollection(
            IEnumerable<DoctorPersistence> doctors)
        {
            return doctors.Select(c => MapDoctorPersistenceToDoctorEntity(c));
        }

        public static DoctorPersistence MapDoctorEntityToDoctorPersistence(Doctor doctor)
        {
            if (doctor == null) return null;

            var retVal = new DoctorPersistence()
            {
                Id = doctor.Id,
                UserType = doctor.UserType,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Password = doctor.Password,
                Specialization =
                    SpecializationMapper.MapSpecializationEntityToSpecializationPersistence(doctor.Specialization)
            };
            return retVal;
        }

        public static IEnumerable<DoctorPersistence> MapDoctorEntityCollectionToDoctorPersistenceCollection(
            IEnumerable<Doctor> doctors)
        {
            return doctors.Select(c => MapDoctorEntityToDoctorPersistence(c));
        }
    }

}
