using SD_IKYS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface IPerformanceEvaluationRepository : IGenericRepository<PerformanceEvaluation>
    {
        Task<IEnumerable<PerformanceEvaluation>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<PerformanceEvaluation>> GetByEvaluatorAsync(int evaluatorId);
        Task<IEnumerable<PerformanceEvaluation>> GetByPeriodAsync(string period);
        Task<IEnumerable<PerformanceEvaluation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PerformanceEvaluation>> GetByStatusAsync(string status);
    }
} 