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
            if (doctor == null) return null;

            return new Doctor();

        }

        public static DoctorPersistence MapDoctorEntityToDoctorPersistence(Doctor doctor)
        {
            if (doctor == null) return null;

            DoctorPersistence retVal = new DoctorPersistence() { Biography = doctor.Biography, EducationLevel = doctor.EducationLevel,
                Id = doctor.Id, Picture = doctor.Picture, PictureNumber = doctor.PictureNumber, SpecializationId = doctor.SpecializationId,
                WorkPlaceId = doctor.WorkPlaceId, WorkRoomId = doctor.WorkRoomId};
            return retVal;
        }

        public static IEnumerable<Doctor> MapDoctorPersistenceCollectionToDoctorEntityCollection(IEnumerable<DoctorPersistence> clients)
            => clients.Select(c => MapDoctorPersistenceToDoctorEntity(c));
    }
}
