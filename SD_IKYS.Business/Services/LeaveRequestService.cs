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
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetAllAsync()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetAllAsync();
            return leaveRequests.Select(MapToDto);
        }

        public async Task<LeaveRequestDto?> GetByIdAsync(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            return leaveRequest != null ? MapToDto(leaveRequest) : null;
        }

        public async Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(createLeaveRequestDto.EmployeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            var leaveRequest = new LeaveRequest
            {
                EmployeeId = createLeaveRequestDto.EmployeeId,
                UserId = createLeaveRequestDto.UserId,
                StartDate = createLeaveRequestDto.StartDate,
                EndDate = createLeaveRequestDto.EndDate,
                LeaveType = createLeaveRequestDto.LeaveType,
                Reason = createLeaveRequestDto.Reason,
                Status = "Pending",
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.LeaveRequests.AddAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(leaveRequest);
        }

        public async Task<LeaveRequestDto> UpdateAsync(int id, UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
                throw new InvalidOperationException("Leave request not found");

            leaveRequest.EmployeeId = updateLeaveRequestDto.EmployeeId;
            leaveRequest.UserId = updateLeaveRequestDto.UserId;
            leaveRequest.StartDate = updateLeaveRequestDto.StartDate;
            leaveRequest.EndDate = updateLeaveRequestDto.EndDate;
            leaveRequest.LeaveType = updateLeaveRequestDto.LeaveType;
            leaveRequest.Reason = updateLeaveRequestDto.Reason;
            leaveRequest.Status = updateLeaveRequestDto.Status;
            leaveRequest.ApproverId = updateLeaveRequestDto.ApproverId;
            leaveRequest.ApprovalDate = updateLeaveRequestDto.ApprovalDate;
            leaveRequest.ApprovalNotes = updateLeaveRequestDto.ApprovalNotes;
            leaveRequest.IsActive = updateLeaveRequestDto.IsActive;
            leaveRequest.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.LeaveRequests.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(leaveRequest);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
                return false;

            await _unitOfWork.LeaveRequests.DeleteAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetByEmployeeAsync(int employeeId)
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetByEmployeeAsync(employeeId);
            return leaveRequests.Select(MapToDto);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetByStatusAsync(string status)
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetByStatusAsync(status);
            return leaveRequests.Select(MapToDto);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetByDateRangeAsync(startDate, endDate);
            return leaveRequests.Select(MapToDto);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetPendingRequestsAsync()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetPendingRequestsAsync();
            return leaveRequests.Select(MapToDto);
        }

        public async Task<LeaveRequestDto> ApproveAsync(int id, ApproveLeaveRequestDto approveDto)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
                throw new InvalidOperationException("Leave request not found");

            leaveRequest.Status = approveDto.Status;
            leaveRequest.ApproverId = approveDto.ApproverId;
            leaveRequest.ApprovalDate = DateTime.UtcNow;
            leaveRequest.ApprovalNotes = approveDto.ApprovalNotes;
            leaveRequest.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.LeaveRequests.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(leaveRequest);
        }

        public async Task<LeaveRequestDto> RejectAsync(int id, RejectLeaveRequestDto rejectDto)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
                throw new InvalidOperationException("Leave request not found");

            leaveRequest.Status = rejectDto.Status;
            leaveRequest.ApproverId = rejectDto.ApproverId;
            leaveRequest.ApprovalDate = DateTime.UtcNow;
            leaveRequest.ApprovalNotes = rejectDto.ApprovalNotes;
            leaveRequest.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.LeaveRequests.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(leaveRequest);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetApprovedRequestsAsync()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetByStatusAsync("Approved");
            return leaveRequests.Select(MapToDto);
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetRejectedRequestsAsync()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetByStatusAsync("Rejected");
            return leaveRequests.Select(MapToDto);
        }

        private LeaveRequestDto MapToDto(LeaveRequest leaveRequest)
        {
            return new LeaveRequestDto
            {
                Id = leaveRequest.Id,
                EmployeeId = leaveRequest.EmployeeId,
                EmployeeName = leaveRequest.Employee != null ? $"{leaveRequest.Employee.FirstName} {leaveRequest.Employee.LastName}" : string.Empty,
                UserId = leaveRequest.UserId,
                UserName = leaveRequest.User?.Username ?? string.Empty,
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                LeaveType = leaveRequest.LeaveType,
                Reason = leaveRequest.Reason,
                Status = leaveRequest.Status,
                ApproverId = leaveRequest.ApproverId,
                ApproverName = leaveRequest.Approver != null ? $"{leaveRequest.Approver.FirstName} {leaveRequest.Approver.LastName}" : string.Empty,
                ApprovalDate = leaveRequest.ApprovalDate,
                ApprovalNotes = leaveRequest.ApprovalNotes,
                IsActive = leaveRequest.IsActive
            };
        }
    }
} 