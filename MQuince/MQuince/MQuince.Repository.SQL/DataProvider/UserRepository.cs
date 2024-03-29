﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Entities.Authentication;
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

        public User AuthenticateUser(AuthenticateRequest user)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            var userFoundInDB = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Email.Equals(user.Email)));
            if (userFoundInDB is null)
                return null;
            return userFoundInDB.Password.Equals(user.Password) ? userFoundInDB : null;
        }


        public User GetById(Guid id)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            User u = UserMapper.MapUserPersistenceToUserEntity(context.Users.SingleOrDefault(u => u.Id.Equals(id)));
            return u;
        }

    }
}
