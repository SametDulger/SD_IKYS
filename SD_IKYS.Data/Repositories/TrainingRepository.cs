using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Training>> GetByTypeAsync(string trainingType)
        {
            return await _dbSet
                .Include(t => t.User)
                .Include(t => t.Participants)
                .Where(t => t.TrainingType == trainingType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(t => t.User)
                .Include(t => t.Participants)
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(t => t.User)
                .Include(t => t.Participants)
                .Where(t => t.StartDate >= startDate && t.EndDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetActiveTrainingsAsync()
        {
            return await _dbSet
                .Include(t => t.User)
                .Include(t => t.Participants)
                .Where(t => t.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetByTrainerAsync(string trainer)
        {
            return await _dbSet
                .Include(t => t.User)
                .Include(t => t.Participants)
                .Where(t => t.Trainer == trainer)
                .ToListAsync();
        }
    }
} 