using MQuince.Entities;
using MQuince.Repository.SQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class UserMapper
    {
        public static User MapUserPersistenceToUserEntity(UserPersistence user)
        {
            return user == null ? null : new User(user.Id, user.UserType, user.Name, user.Surname, user.Email, user.Password);
        }

        public static IEnumerable<User> MapUserPersistenceCollectionToUserEntityCollection(
            IEnumerable<UserPersistence> users)
        {
            return users.Select(c => MapUserPersistenceToUserEntity(c));
        }

        public static UserPersistence MapUserEntityToUserPersistence(User user)
        {
            if (user == null) return null;

            var retVal = new UserPersistence()
            {
                Id = user.Id,
                UserType = user.UserType,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password
            };
            return retVal;
        }

        public static IEnumerable<UserPersistence> MapUserEntityCollectionToUserPersistenceCollection(
            IEnumerable<User> users)
        {
            return users.Select(c => MapUserEntityToUserPersistence(c));
        }
    }
}
