using SD_IKYS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface ITrainingParticipantRepository : IGenericRepository<TrainingParticipant>
    {
        Task<IEnumerable<TrainingParticipant>> GetByTrainingAsync(int trainingId);
        Task<IEnumerable<TrainingParticipant>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<TrainingParticipant>> GetByStatusAsync(string status);
        Task<bool> IsEmployeeRegisteredAsync(int trainingId, int employeeId);
    }
} 