using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class TrainingDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TrainingType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Trainer { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateTrainingDto
    {
        [Required(ErrorMessage = "Eğitim başlığı zorunludur")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim türü zorunludur")]
        [StringLength(50, ErrorMessage = "Eğitim türü en fazla 50 karakter olabilir")]
        public string TrainingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [StringLength(100, ErrorMessage = "Eğitmen adı en fazla 100 karakter olabilir")]
        public string Trainer { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Konum en fazla 200 karakter olabilir")]
        public string Location { get; set; } = string.Empty;

        [Range(1, 1000, ErrorMessage = "Maksimum katılımcı sayısı 1-1000 arasında olmalıdır")]
        public int MaxParticipants { get; set; }

        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
    }

    public class UpdateTrainingDto
    {
        [Required(ErrorMessage = "Eğitim başlığı zorunludur")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim türü zorunludur")]
        [StringLength(50, ErrorMessage = "Eğitim türü en fazla 50 karakter olabilir")]
        public string TrainingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [StringLength(100, ErrorMessage = "Eğitmen adı en fazla 100 karakter olabilir")]
        public string Trainer { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Konum en fazla 200 karakter olabilir")]
        public string Location { get; set; } = string.Empty;

        [Range(1, 1000, ErrorMessage = "Maksimum katılımcı sayısı 1-1000 arasında olmalıdır")]
        public int MaxParticipants { get; set; }

        [StringLength(20, ErrorMessage = "Durum en fazla 20 karakter olabilir")]
        public string Status { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateTrainingScoreDto
    {
        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        public DateTime? CompletionDate { get; set; }

        [StringLength(200)]
        public string CertificateNumber { get; set; } = string.Empty;
    }
} 