using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LeaveType { get; set; } // Annual, Sick, Unpaid, etc.

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public int? ApproverId { get; set; }
        public virtual Employee Approver { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(200)]
        public string ApprovalNotes { get; set; }
    }
} 