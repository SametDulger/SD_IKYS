using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(lr => lr.Employee)
                .Include(lr => lr.User)
                .Include(lr => lr.Approver)
                .Where(lr => lr.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(lr => lr.Employee)
                .Include(lr => lr.User)
                .Include(lr => lr.Approver)
                .Where(lr => lr.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(lr => lr.Employee)
                .Include(lr => lr.User)
                .Include(lr => lr.Approver)
                .Where(lr => lr.StartDate >= startDate && lr.EndDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetPendingRequestsAsync()
        {
            return await _dbSet
                .Include(lr => lr.Employee)
                .Include(lr => lr.User)
                .Include(lr => lr.Approver)
                .Where(lr => lr.Status == "Pending")
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetByApproverAsync(int approverId)
        {
            return await _dbSet
                .Include(lr => lr.Employee)
                .Include(lr => lr.User)
                .Include(lr => lr.Approver)
                .Where(lr => lr.ApproverId == approverId)
                .ToListAsync();
        }
    }
} 