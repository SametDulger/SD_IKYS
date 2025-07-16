using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class TrainingParticipantViewModel
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal? Score { get; set; }
        public string Certificate { get; set; } = string.Empty;
        public string CertificateNumber { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime? CompletionDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TrainingParticipantCreateViewModel
    {
        [Required(ErrorMessage = "Eğitim seçimi zorunludur")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [StringLength(500, ErrorMessage = "Yorumlar en fazla 500 karakter olabilir")]
        public string Comments { get; set; } = string.Empty;
    }

    public class TrainingParticipantEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Eğitim seçimi zorunludur")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Puan 0-100 arasında olmalıdır")]
        public decimal? Score { get; set; }

        [StringLength(200, ErrorMessage = "Sertifika bilgisi en fazla 200 karakter olabilir")]
        public string Certificate { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Sertifika numarası en fazla 200 karakter olabilir")]
        public string CertificateNumber { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Yorumlar en fazla 500 karakter olabilir")]
        public string Comments { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir")]
        public string Notes { get; set; } = string.Empty;

        public DateTime? CompletionDate { get; set; }
    }

    public class TrainingParticipantScoreViewModel
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
} 