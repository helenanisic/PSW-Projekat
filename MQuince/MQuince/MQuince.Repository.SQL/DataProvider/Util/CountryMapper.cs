using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class CountryMapper
    {
        public static Country MapCountryPersistenceToCountryEntity(CountryPersistence country)
        {
            return country == null ? null : new Country(country.Id, country.Name);
        }

        public static IEnumerable<Country> MapCountryPersistenceCollectionToCountryEntityCollection(
            IEnumerable<CountryPersistence> countries)
        {
            return countries.Select(c => MapCountryPersistenceToCountryEntity(c));
        }

        public static CountryPersistence MapCountryEntityToCountryPersistence(Country country)
        {
            if (country == null) return null;

            var retVal = new CountryPersistence()
            {
                Id = country.Id,
                Name = country.Name
            };
            return retVal;
        }

        public static IEnumerable<CountryPersistence> MapCountryEntityCollectionToCountryPersistenceCollection(
            IEnumerable<Country> countries)
        {
            return countries.Select(c => MapCountryEntityToCountryPersistence(c));
        }
    }
}