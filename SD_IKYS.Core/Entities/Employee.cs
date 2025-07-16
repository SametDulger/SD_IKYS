using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
        public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<TrainingParticipant> TrainingParticipants { get; set; }
    }
} 