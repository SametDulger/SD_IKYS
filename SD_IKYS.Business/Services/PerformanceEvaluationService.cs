using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Services
{
    public class PerformanceEvaluationService : IPerformanceEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PerformanceEvaluationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetAllAsync()
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetAllAsync();
            return evaluations.Select(MapToDto);
        }

        public async Task<PerformanceEvaluationDto> GetByIdAsync(int id)
        {
            var evaluation = await _unitOfWork.PerformanceEvaluations.GetByIdAsync(id);
            return evaluation != null ? MapToDto(evaluation) : null;
        }

        public async Task<PerformanceEvaluationDto> CreateAsync(CreatePerformanceEvaluationDto createDto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(createDto.EmployeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            var evaluator = await _unitOfWork.Employees.GetByIdAsync(createDto.EvaluatorId);
            if (evaluator == null)
                throw new InvalidOperationException("Evaluator not found");

            var overallScore = CalculateOverallScore(createDto);

            var evaluation = new PerformanceEvaluation
            {
                EmployeeId = createDto.EmployeeId,
                UserId = createDto.UserId,
                EvaluatorId = createDto.EvaluatorId,
                EvaluationDate = createDto.EvaluationDate,
                EvaluationPeriod = createDto.EvaluationPeriod,
                WorkQuality = createDto.WorkQuality,
                Productivity = createDto.Productivity,
                Teamwork = createDto.Teamwork,
                Communication = createDto.Communication,
                Initiative = createDto.Initiative,
                OverallScore = overallScore,
                Strengths = createDto.Strengths,
                AreasForImprovement = createDto.AreasForImprovement,
                Goals = createDto.Goals,
                Status = "Draft",
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.PerformanceEvaluations.AddAsync(evaluation);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(evaluation);
        }

        public async Task<PerformanceEvaluationDto> UpdateAsync(int id, UpdatePerformanceEvaluationDto updateDto)
        {
            var evaluation = await _unitOfWork.PerformanceEvaluations.GetByIdAsync(id);
            if (evaluation == null)
                throw new InvalidOperationException("Performance evaluation not found");

            var overallScore = CalculateOverallScore(updateDto);

            evaluation.EmployeeId = updateDto.EmployeeId;
            evaluation.UserId = updateDto.UserId;
            evaluation.EvaluatorId = updateDto.EvaluatorId;
            evaluation.EvaluationDate = updateDto.EvaluationDate;
            evaluation.EvaluationPeriod = updateDto.EvaluationPeriod;
            evaluation.WorkQuality = updateDto.WorkQuality;
            evaluation.Productivity = updateDto.Productivity;
            evaluation.Teamwork = updateDto.Teamwork;
            evaluation.Communication = updateDto.Communication;
            evaluation.Initiative = updateDto.Initiative;
            evaluation.OverallScore = overallScore;
            evaluation.Strengths = updateDto.Strengths;
            evaluation.AreasForImprovement = updateDto.AreasForImprovement;
            evaluation.Goals = updateDto.Goals;
            evaluation.Status = updateDto.Status;
            evaluation.IsActive = updateDto.IsActive;
            evaluation.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.PerformanceEvaluations.UpdateAsync(evaluation);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(evaluation);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var evaluation = await _unitOfWork.PerformanceEvaluations.GetByIdAsync(id);
            if (evaluation == null)
                return false;

            await _unitOfWork.PerformanceEvaluations.DeleteAsync(evaluation);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetByEmployeeAsync(int employeeId)
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetByEmployeeAsync(employeeId);
            return evaluations.Select(MapToDto);
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetByEvaluatorAsync(int evaluatorId)
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetByEvaluatorAsync(evaluatorId);
            return evaluations.Select(MapToDto);
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetByPeriodAsync(string period)
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetByPeriodAsync(period);
            return evaluations.Select(MapToDto);
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetByDateRangeAsync(startDate, endDate);
            return evaluations.Select(MapToDto);
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetByStatusAsync(string status)
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetByStatusAsync(status);
            return evaluations.Select(MapToDto);
        }

        public async Task<IEnumerable<PerformanceEvaluationDto>> GetHighPerformersAsync()
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetAllAsync();
            return evaluations
                .Where(e => e.OverallScore >= 4.0m)
                .Select(MapToDto)
                .OrderByDescending(e => e.OverallScore);
        }

        public async Task<object> GetReportAsync()
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetAllAsync();
            var activeEvaluations = evaluations.Where(e => e.IsActive).ToList();

            var report = new
            {
                TotalEvaluations = activeEvaluations.Count,
                AverageScore = activeEvaluations.Any() ? activeEvaluations.Average(e => e.OverallScore) : 0,
                HighPerformers = activeEvaluations.Count(e => e.OverallScore >= 4.0m),
                LowPerformers = activeEvaluations.Count(e => e.OverallScore < 3.0m),
                CompletedEvaluations = activeEvaluations.Count(e => e.Status == "Completed"),
                PendingEvaluations = activeEvaluations.Count(e => e.Status == "Draft")
            };

            return report;
        }

        public async Task<decimal> GetAverageScoreAsync()
        {
            var evaluations = await _unitOfWork.PerformanceEvaluations.GetAllAsync();
            var activeEvaluations = evaluations.Where(e => e.IsActive).ToList();
            
            return activeEvaluations.Any() ? activeEvaluations.Average(e => e.OverallScore) : 0;
        }

        private decimal CalculateOverallScore(dynamic evaluationDto)
        {
            return (evaluationDto.WorkQuality + evaluationDto.Productivity + evaluationDto.Teamwork + 
                   evaluationDto.Communication + evaluationDto.Initiative) / 5.0m;
        }

        private PerformanceEvaluationDto MapToDto(PerformanceEvaluation evaluation)
        {
            return new PerformanceEvaluationDto
            {
                Id = evaluation.Id,
                EmployeeId = evaluation.EmployeeId,
                EmployeeName = evaluation.Employee != null ? $"{evaluation.Employee.FirstName} {evaluation.Employee.LastName}" : null,
                UserId = evaluation.UserId,
                UserName = evaluation.User != null ? evaluation.User.Username : null,
                EvaluatorId = evaluation.EvaluatorId,
                EvaluatorName = evaluation.Evaluator != null ? $"{evaluation.Evaluator.FirstName} {evaluation.Evaluator.LastName}" : null,
                EvaluationDate = evaluation.EvaluationDate,
                EvaluationPeriod = evaluation.EvaluationPeriod,
                WorkQuality = evaluation.WorkQuality,
                Productivity = evaluation.Productivity,
                Teamwork = evaluation.Teamwork,
                Communication = evaluation.Communication,
                Initiative = evaluation.Initiative,
                OverallScore = evaluation.OverallScore,
                Strengths = evaluation.Strengths,
                AreasForImprovement = evaluation.AreasForImprovement,
                Goals = evaluation.Goals,
                Status = evaluation.Status,
                IsActive = evaluation.IsActive
            };
        }
    }
} 