using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class PerformanceEvaluationRepository : GenericRepository<PerformanceEvaluation>, IPerformanceEvaluationRepository
    {
        public PerformanceEvaluationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PerformanceEvaluation>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(pe => pe.Employee)
                .Include(pe => pe.User)
                .Include(pe => pe.Evaluator)
                .Where(pe => pe.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PerformanceEvaluation>> GetByEvaluatorAsync(int evaluatorId)
        {
            return await _dbSet
                .Include(pe => pe.Employee)
                .Include(pe => pe.User)
                .Include(pe => pe.Evaluator)
                .Where(pe => pe.EvaluatorId == evaluatorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PerformanceEvaluation>> GetByPeriodAsync(string period)
        {
            return await _dbSet
                .Include(pe => pe.Employee)
                .Include(pe => pe.User)
                .Include(pe => pe.Evaluator)
                .Where(pe => pe.EvaluationPeriod == period)
                .ToListAsync();
        }

        public async Task<IEnumerable<PerformanceEvaluation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(pe => pe.Employee)
                .Include(pe => pe.User)
                .Include(pe => pe.Evaluator)
                .Where(pe => pe.EvaluationDate >= startDate && pe.EvaluationDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<PerformanceEvaluation>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(pe => pe.Employee)
                .Include(pe => pe.User)
                .Include(pe => pe.Evaluator)
                .Where(pe => pe.Status == status)
                .ToListAsync();
        }
    }
} 