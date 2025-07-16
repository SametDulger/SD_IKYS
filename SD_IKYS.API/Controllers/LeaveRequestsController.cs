using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetAll()
        {
            var leaveRequests = await _leaveRequestService.GetAllAsync();
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leaveRequest = await _leaveRequestService.GetByIdAsync(id);
            if (leaveRequest == null)
                return NotFound();

            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRequestDto>> Create(CreateLeaveRequestDto createLeaveRequestDto)
        {
            try
            {
                var leaveRequest = await _leaveRequestService.CreateAsync(createLeaveRequestDto);
                return CreatedAtAction(nameof(GetById), new { id = leaveRequest.Id }, leaveRequest);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Update(int id, UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            try
            {
                var leaveRequest = await _leaveRequestService.UpdateAsync(id, updateLeaveRequestDto);
                return Ok(leaveRequest);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _leaveRequestService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetByEmployee(int employeeId)
        {
            var leaveRequests = await _leaveRequestService.GetByEmployeeAsync(employeeId);
            return Ok(leaveRequests);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetByStatus(string status)
        {
            var leaveRequests = await _leaveRequestService.GetByStatusAsync(status);
            return Ok(leaveRequests);
        }

        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetPending()
        {
            var leaveRequests = await _leaveRequestService.GetPendingRequestsAsync();
            return Ok(leaveRequests);
        }

        [HttpPost("{id}/approve")]
        public async Task<ActionResult<LeaveRequestDto>> Approve(int id, ApproveLeaveRequestDto approveDto)
        {
            try
            {
                var leaveRequest = await _leaveRequestService.ApproveAsync(id, approveDto);
                return Ok(leaveRequest);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/reject")]
        public async Task<ActionResult<LeaveRequestDto>> Reject(int id, RejectLeaveRequestDto rejectDto)
        {
            try
            {
                var leaveRequest = await _leaveRequestService.RejectAsync(id, rejectDto);
                return Ok(leaveRequest);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("approved")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetApproved()
        {
            var leaveRequests = await _leaveRequestService.GetApprovedRequestsAsync();
            return Ok(leaveRequests);
        }

        [HttpGet("rejected")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetRejected()
        {
            var leaveRequests = await _leaveRequestService.GetRejectedRequestsAsync();
            return Ok(leaveRequests);
        }
    }
} 