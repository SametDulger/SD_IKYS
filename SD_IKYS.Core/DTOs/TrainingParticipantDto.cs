using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class TrainingParticipantDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal? Score { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string CertificateNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string TrainingTitle { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateTrainingParticipantDto
    {
        [Required(ErrorMessage = "Eğitim seçimi zorunludur")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Çalışan seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [StringLength(20, ErrorMessage = "Durum en fazla 20 karakter olabilir")]
        public string Status { get; set; } = "Registered";

        [Range(0, 100, ErrorMessage = "Puan 0-100 arasında olmalıdır")]
        public decimal? Score { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(200, ErrorMessage = "Sertifika numarası en fazla 200 karakter olabilir")]
        public string CertificateNumber { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string Notes { get; set; } = string.Empty;
    }

    public class UpdateTrainingParticipantDto
    {
        [Required(ErrorMessage = "Eğitim seçimi zorunludur")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Çalışan seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [StringLength(20, ErrorMessage = "Durum en fazla 20 karakter olabilir")]
        public string Status { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Puan 0-100 arasında olmalıdır")]
        public decimal? Score { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(200, ErrorMessage = "Sertifika numarası en fazla 200 karakter olabilir")]
        public string CertificateNumber { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 