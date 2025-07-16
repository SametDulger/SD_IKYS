using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace SD_IKYS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository? _users;
        private IRoleRepository? _roles;
        private IEmployeeRepository? _employees;
        private ILeaveRequestRepository? _leaveRequests;
        private IPerformanceEvaluationRepository? _performanceEvaluations;
        private ITrainingRepository? _trainings;
        private ITrainingParticipantRepository? _trainingParticipants;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IRoleRepository Roles => _roles ??= new RoleRepository(_context);
        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);
        public ILeaveRequestRepository LeaveRequests => _leaveRequests ??= new LeaveRequestRepository(_context);
        public IPerformanceEvaluationRepository PerformanceEvaluations => _performanceEvaluations ??= new PerformanceEvaluationRepository(_context);
        public ITrainingRepository Trainings => _trainings ??= new TrainingRepository(_context);
        public ITrainingParticipantRepository TrainingParticipants => _trainingParticipants ??= new TrainingParticipantRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
} 