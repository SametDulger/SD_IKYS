using SD_IKYS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDto>> GetAllAsync();
        Task<TrainingDto?> GetByIdAsync(int id);
        Task<TrainingDto> CreateAsync(CreateTrainingDto createTrainingDto);
        Task<TrainingDto> UpdateAsync(int id, UpdateTrainingDto updateTrainingDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TrainingDto>> GetByTypeAsync(string trainingType);
        Task<IEnumerable<TrainingDto>> GetByStatusAsync(string status);
        Task<IEnumerable<TrainingDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TrainingDto>> GetActiveTrainingsAsync();
        Task<IEnumerable<TrainingDto>> GetByTrainerAsync(string trainer);
        Task<IEnumerable<TrainingDto>> GetUpcomingTrainingsAsync();
        Task<IEnumerable<TrainingDto>> GetCompletedTrainingsAsync();
        Task<IEnumerable<TrainingDto>> GetCancelledTrainingsAsync();
    }
} 