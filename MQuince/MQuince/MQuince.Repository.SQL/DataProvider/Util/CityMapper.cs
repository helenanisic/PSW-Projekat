using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class CityMapper
    {
        public static City MapCityPersistenceToCityEntity(CityPersistence city)
        {
            return city == null ? null : new City(city.Id, city.Name, city.PostNumber, CountryMapper.MapCountryPersistenceToCountryEntity(city.Country));
        }

        public static IEnumerable<City> MapCityPersistenceCollectionToCityEntityCollection(
            IEnumerable<CityPersistence> cities)
        {
            return cities.Select(c => MapCityPersistenceToCityEntity(c));
        }

        public static CityPersistence MapCityEntityToCityPersistence(City city)
        {
            if (city == null) return null;

            var retVal = new CityPersistence()
            {
                Id = city.Id,
                Name = city.Name,
                PostNumber = city.PostNumber,
                Country = CountryMapper.MapCountryEntityToCountryPersistence(city.Country)
            };
            return retVal;
        }

        public static IEnumerable<CityPersistence> MapCityEntityCollectionToCityPersistenceCollection(
            IEnumerable<City> cities)
        {
            return cities.Select(c => MapCityEntityToCityPersistence(c));
        }
    }
}
