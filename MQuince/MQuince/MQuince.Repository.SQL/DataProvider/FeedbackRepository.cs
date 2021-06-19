using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Services.Contracts.DTO.Communication;

namespace MQuince.Repository.SQL.DataProvider
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbContextOptions _dbContext;

        public FeedbackRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public Guid Create(Feedback entity)
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            context.Feedbacks.Add(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity));
            return context.SaveChanges() > 0 ? entity.Id : Guid.Empty;
        }

        public IEnumerable<Feedback> GetAll()
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(context.Feedbacks.ToList());
        }

        public IEnumerable<ViewFeedbackDTO> GetAllFeedbacks()
        {
            using MQuinceDbContext context = new MQuinceDbContext(_dbContext);
            return FeedbackMapper.MapFeedbackPersistenceCollectionToViewFeedbackDTOCollection(context.Feedbacks.Include("Patient").ToList());
        }

        public IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks()
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return FeedbackMapper.MapFeedbackPersistenceCollectionToViewFeedbackDTOCollection(_context.Feedbacks.Include("Patient").Where(p => p.Published == false).ToList());
        }

        public IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks()
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return FeedbackMapper.MapFeedbackPersistenceCollectionToViewFeedbackDTOCollection(_context.Feedbacks.Include("Patient").Where(p => p.Published == true).ToList());
        }

        public Feedback Update(Feedback entity)
        {
            using MQuinceDbContext _context = new MQuinceDbContext(_dbContext);
            return FeedbackMapper.MapFeedbackPersistenceToFeedbackEntity(_context.Update(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity)).Entity);
            
        }
        
    }
}
