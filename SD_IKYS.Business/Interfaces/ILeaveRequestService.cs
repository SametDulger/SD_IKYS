using SD_IKYS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequestDto>> GetAllAsync();
        Task<LeaveRequestDto?> GetByIdAsync(int id);
        Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto);
        Task<LeaveRequestDto> UpdateAsync(int id, UpdateLeaveRequestDto updateLeaveRequestDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<LeaveRequestDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<LeaveRequestDto>> GetByStatusAsync(string status);
        Task<IEnumerable<LeaveRequestDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<LeaveRequestDto>> GetPendingRequestsAsync();
        Task<LeaveRequestDto> ApproveAsync(int id, ApproveLeaveRequestDto approveDto);
        Task<LeaveRequestDto> RejectAsync(int id, RejectLeaveRequestDto rejectDto);
        Task<IEnumerable<LeaveRequestDto>> GetApprovedRequestsAsync();
        Task<IEnumerable<LeaveRequestDto>> GetRejectedRequestsAsync();
    }
} 