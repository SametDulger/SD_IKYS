using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        [StringLength(50)]
        public string Position { get; set; } = string.Empty;

        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public virtual Employee? Manager { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; set; } = new List<PerformanceEvaluation>();
        public virtual ICollection<Training> Trainings { get; set; } = new List<Training>();
        public virtual ICollection<TrainingParticipant> TrainingParticipants { get; set; } = new List<TrainingParticipant>();
    }
} 