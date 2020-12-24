using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Services.Contracts.DTO.Users;

namespace MQuince.Repository.SQL.DataProvider
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions _dbContext;

        public UserRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public bool AuthenticateUser(UserLoginDTO user)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            User u = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Email.Equals(user.Email)));
            if (u.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
