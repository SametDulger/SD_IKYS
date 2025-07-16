using System;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IEmployeeRepository Employees { get; }
        ILeaveRequestRepository LeaveRequests { get; }
        IPerformanceEvaluationRepository PerformanceEvaluations { get; }
        ITrainingRepository Trainings { get; }
        ITrainingParticipantRepository TrainingParticipants { get; }

        Task<int> SaveChangesAsync();
    }
} 