using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Enums;
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

        public Guid AuthenticateUser(UserLoginDTO user)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            var userFoundInDB = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Email.Equals(user.Email)));
            if (userFoundInDB is null)
                return Guid.Empty;
            return userFoundInDB.Password.Equals(user.Password) ? userFoundInDB.Id : Guid.Empty;
        }

        public Guid Create(User entity)
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

        public bool IsUserTypeAdmin(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            User u = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Id.Equals(id)));
            return u.UserType == Usertype.Admin;
        }

        public bool IsUserTypePatient(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            User u = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Id.Equals(id)));
            return u.UserType == Usertype.Patient;

        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
