using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int? ApproverId { get; set; }
        public string ApproverName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalNotes { get; set; }
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
        public string LeaveType { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }
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
        public string LeaveType { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public int? ApproverId { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(200)]
        public string ApprovalNotes { get; set; }

        public bool IsActive { get; set; }
    }

    public class ApproveLeaveRequestDto
    {
        [Required]
        public int ApproverId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(200)]
        public string ApprovalNotes { get; set; }
    }

    public class RejectLeaveRequestDto
    {
        [Required]
        public int ApproverId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(200)]
        public string ApprovalNotes { get; set; }
    }
} 