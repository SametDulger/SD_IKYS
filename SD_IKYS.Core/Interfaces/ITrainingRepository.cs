using SD_IKYS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface ITrainingRepository : IGenericRepository<Training>
    {
        Task<IEnumerable<Training>> GetByTypeAsync(string trainingType);
        Task<IEnumerable<Training>> GetByStatusAsync(string status);
        Task<IEnumerable<Training>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Training>> GetActiveTrainingsAsync();
        Task<IEnumerable<Training>> GetByTrainerAsync(string trainer);
    }
} 