using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class SpecializationMapper
    {
        public static Specialization MapSpecializationPersistenceToSpecializationEntity(SpecializationPersistence specialization)
        {
            return specialization == null ? null : new Specialization(specialization.Id, specialization.Name);
        }

        public static IEnumerable<Specialization> MapSpecializationPersistenceCollectionToSpecializationEntityCollection(
            IEnumerable<SpecializationPersistence> specialization)
        {
            return specialization.Select(c => MapSpecializationPersistenceToSpecializationEntity(c));
        }

        public static SpecializationPersistence MapSpecializationEntityToSpecializationPersistence(Specialization specialization)
        {
            if (specialization == null) return null;

            var retVal = new SpecializationPersistence()
            {
                Id = specialization.Id,
                Name = specialization.Name
            };
            return retVal;
        }

        public static IEnumerable<SpecializationPersistence> MapSpecializationEntityCollectionToSpecializationPersistenceCollection(
            IEnumerable<Specialization> specializations)
        {
            return specializations.Select(c => MapSpecializationEntityToSpecializationPersistence(c));
        }
    }
}
