using SD_IKYS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface IPerformanceEvaluationService
    {
        Task<IEnumerable<PerformanceEvaluationDto>> GetAllAsync();
        Task<PerformanceEvaluationDto> GetByIdAsync(int id);
        Task<PerformanceEvaluationDto> CreateAsync(CreatePerformanceEvaluationDto createDto);
        Task<PerformanceEvaluationDto> UpdateAsync(int id, UpdatePerformanceEvaluationDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PerformanceEvaluationDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<PerformanceEvaluationDto>> GetByEvaluatorAsync(int evaluatorId);
        Task<IEnumerable<PerformanceEvaluationDto>> GetByPeriodAsync(string period);
        Task<IEnumerable<PerformanceEvaluationDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PerformanceEvaluationDto>> GetByStatusAsync(string status);
        Task<IEnumerable<PerformanceEvaluationDto>> GetHighPerformersAsync();
        Task<object> GetReportAsync();
        Task<decimal> GetAverageScoreAsync();
    }
} 