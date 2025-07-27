using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class PerformanceEvaluationDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int EvaluatorId { get; set; }
        public string EvaluatorName { get; set; } = string.Empty;
        public DateTime EvaluationDate { get; set; }
        public string EvaluationPeriod { get; set; } = string.Empty;
        public int WorkQuality { get; set; }
        public int Productivity { get; set; }
        public int Teamwork { get; set; }
        public int Communication { get; set; }
        public int Initiative { get; set; }
        public decimal OverallScore { get; set; }
        public string Strengths { get; set; } = string.Empty;
        public string AreasForImprovement { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreatePerformanceEvaluationDto
    {
        [Required]
        public int EmployeeId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public int EvaluatorId { get; set; }

        [Required]
        public DateTime EvaluationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EvaluationPeriod { get; set; } = string.Empty;

        [Range(1, 5)]
        public int WorkQuality { get; set; }

        [Range(1, 5)]
        public int Productivity { get; set; }

        [Range(1, 5)]
        public int Teamwork { get; set; }

        [Range(1, 5)]
        public int Communication { get; set; }

        [Range(1, 5)]
        public int Initiative { get; set; }

        [StringLength(1000)]
        public string Strengths { get; set; } = string.Empty;

        [StringLength(1000)]
        public string AreasForImprovement { get; set; } = string.Empty;

        [StringLength(500)]
        public string Goals { get; set; } = string.Empty;
    }

    public class UpdatePerformanceEvaluationDto
    {
        [Required]
        public int EmployeeId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public int EvaluatorId { get; set; }

        [Required]
        public DateTime EvaluationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EvaluationPeriod { get; set; } = string.Empty;

        [Range(1, 5)]
        public int WorkQuality { get; set; }

        [Range(1, 5)]
        public int Productivity { get; set; }

        [Range(1, 5)]
        public int Teamwork { get; set; }

        [Range(1, 5)]
        public int Communication { get; set; }

        [Range(1, 5)]
        public int Initiative { get; set; }

        [StringLength(1000)]
        public string Strengths { get; set; } = string.Empty;

        [StringLength(1000)]
        public string AreasForImprovement { get; set; } = string.Empty;

        [StringLength(500)]
        public string Goals { get; set; } = string.Empty;

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
} 