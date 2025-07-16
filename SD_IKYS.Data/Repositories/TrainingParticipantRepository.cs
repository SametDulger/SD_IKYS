using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class TrainingParticipantRepository : GenericRepository<TrainingParticipant>, ITrainingParticipantRepository
    {
        public TrainingParticipantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TrainingParticipant>> GetByTrainingAsync(int trainingId)
        {
            return await _dbSet
                .Include(tp => tp.Training)
                .Include(tp => tp.Employee)
                .Where(tp => tp.TrainingId == trainingId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TrainingParticipant>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(tp => tp.Training)
                .Include(tp => tp.Employee)
                .Where(tp => tp.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TrainingParticipant>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(tp => tp.Training)
                .Include(tp => tp.Employee)
                .Where(tp => tp.Status == status)
                .ToListAsync();
        }

        public async Task<bool> IsEmployeeRegisteredAsync(int trainingId, int employeeId)
        {
            return await _dbSet.AnyAsync(tp => tp.TrainingId == trainingId && tp.EmployeeId == employeeId);
        }
    }
} 