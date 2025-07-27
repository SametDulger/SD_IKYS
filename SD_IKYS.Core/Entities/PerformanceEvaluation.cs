using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class PerformanceEvaluation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public int EvaluatorId { get; set; }
        public virtual Employee Evaluator { get; set; } = null!;

        public DateTime EvaluationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EvaluationPeriod { get; set; } = string.Empty; // Q1, Q2, Q3, Q4, Annual

        public int WorkQuality { get; set; } // 1-5 scale
        public int Productivity { get; set; } // 1-5 scale
        public int Teamwork { get; set; } // 1-5 scale
        public int Communication { get; set; } // 1-5 scale
        public int Initiative { get; set; } // 1-5 scale

        public decimal OverallScore { get; set; }

        [StringLength(1000)]
        public string Strengths { get; set; } = string.Empty;

        [StringLength(1000)]
        public string AreasForImprovement { get; set; } = string.Empty;

        [StringLength(500)]
        public string Goals { get; set; } = string.Empty;

        [StringLength(20)]
        public string Status { get; set; } = "Draft"; // Draft, Completed, Reviewed
    }
} 