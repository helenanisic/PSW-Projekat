using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class AdressMapper
    {
        public static Adress MapAdressPersistenceToAdressEntity(AdressPersistence adress)
        {
            return adress == null ? null : new Adress(adress.Id, adress.Number, adress.Street, adress.CityId);
        }

        public static IEnumerable<Adress> MapAdressPersistenceCollectionToAdressEntityCollection(
            IEnumerable<AdressPersistence> adresses)
        {
            return adresses.Select(c => MapAdressPersistenceToAdressEntity(c));
        }

        public static AdressPersistence MapAdressEntityToAdressPersistence(Adress adress)
        {
            if (adress == null) return null;

            var retVal = new AdressPersistence()
            {
                Id = adress.Id,
                Number = adress.Number,
                Street = adress.Street,
                CityId = adress.CityId
            };
            return retVal;
        }

        public static IEnumerable<AdressPersistence> MapAdressEntityCollectionToAdressPersistenceCollection(
            IEnumerable<Adress> adresses)
        {
            return adresses.Select(c => MapAdressEntityToAdressPersistence(c));
        }
    }
}
