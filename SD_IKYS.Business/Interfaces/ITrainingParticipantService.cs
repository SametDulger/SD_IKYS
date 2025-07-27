using SD_IKYS.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface ITrainingParticipantService
    {
        Task<IEnumerable<TrainingParticipantDto>> GetAllAsync();
        Task<TrainingParticipantDto?> GetByIdAsync(int id);
        Task<TrainingParticipantDto> CreateAsync(CreateTrainingParticipantDto createDto);
        Task<TrainingParticipantDto> UpdateAsync(int id, UpdateTrainingParticipantDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TrainingParticipantDto>> GetByTrainingAsync(int trainingId);
        Task<IEnumerable<TrainingParticipantDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<TrainingParticipantDto>> GetByStatusAsync(string status);
        Task<bool> IsEmployeeRegisteredAsync(int trainingId, int employeeId);
        Task<TrainingParticipantDto> UpdateScoreAsync(int id, UpdateTrainingScoreDto scoreDto);
        Task<IEnumerable<TrainingParticipantDto>> GetCompletedParticipantsAsync();
        Task<IEnumerable<TrainingParticipantDto>> GetPendingParticipantsAsync();
        Task<IEnumerable<TrainingParticipantDto>> GetHighScoreParticipantsAsync();
    }
} 