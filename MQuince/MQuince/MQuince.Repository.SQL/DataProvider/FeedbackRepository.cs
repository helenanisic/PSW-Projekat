using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Repository.Contracts;

namespace MQuince.Repository.SQL.DataProvider
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbContextOptions _dbContext;

        public FeedbackRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public Feedback GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
