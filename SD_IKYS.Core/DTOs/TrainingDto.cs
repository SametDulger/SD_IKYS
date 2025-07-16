using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class TrainingDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrainingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Trainer { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int ParticipantCount { get; set; }
    }

    public class CreateTrainingDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [StringLength(100)]
        public string Trainer { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public int MaxParticipants { get; set; }

        public int? UserId { get; set; }
    }

    public class UpdateTrainingDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [StringLength(100)]
        public string Trainer { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public int MaxParticipants { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public int? UserId { get; set; }

        public bool IsActive { get; set; }
    }

    public class TrainingParticipantDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public decimal? Score { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string CertificateNumber { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateTrainingParticipantDto
    {
        [Required]
        public int TrainingId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }

    public class UpdateTrainingParticipantDto
    {
        [Required]
        public int TrainingId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(200)]
        public string CertificateNumber { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateTrainingScoreDto
    {
        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(200)]
        public string CertificateNumber { get; set; }
    }
} 