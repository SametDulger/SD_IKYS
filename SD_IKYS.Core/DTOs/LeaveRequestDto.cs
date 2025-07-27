using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? ApproverId { get; set; }
        public string ApproverName { get; set; } = string.Empty;
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalNotes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreateLeaveRequestDto
    {
        [Required]
        public int EmployeeId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LeaveType { get; set; } = string.Empty;

        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;
    }

    public class UpdateLeaveRequestDto
    {
        [Required]
        public int EmployeeId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LeaveType { get; set; } = string.Empty;

        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        public int? ApproverId { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(200)]
        public string ApprovalNotes { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }

    public class ApproveLeaveRequestDto
    {
        [Required]
        public int ApproverId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        [StringLength(200)]
        public string ApprovalNotes { get; set; } = string.Empty;
    }

    public class RejectLeaveRequestDto
    {
        [Required]
        public int ApproverId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        [StringLength(200)]
        public string ApprovalNotes { get; set; } = string.Empty;
    }
} 