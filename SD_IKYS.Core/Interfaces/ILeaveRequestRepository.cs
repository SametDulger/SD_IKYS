using SD_IKYS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<LeaveRequest>> GetByStatusAsync(string status);
        Task<IEnumerable<LeaveRequest>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<LeaveRequest>> GetPendingRequestsAsync();
        Task<IEnumerable<LeaveRequest>> GetByApproverAsync(int approverId);
    }
} 