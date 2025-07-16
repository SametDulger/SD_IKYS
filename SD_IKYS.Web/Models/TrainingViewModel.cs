using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TrainingType { get; set; } = string.Empty;
        public string Trainer { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class TrainingCreateViewModel
    {
        [Required(ErrorMessage = "Eğitim başlığı zorunludur")]
        [StringLength(100, ErrorMessage = "Eğitim başlığı en fazla 100 karakter olabilir")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim açıklaması zorunludur")]
        [StringLength(1000, ErrorMessage = "Eğitim açıklaması en fazla 1000 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim türü zorunludur")]
        [StringLength(50, ErrorMessage = "Eğitim türü en fazla 50 karakter olabilir")]
        public string TrainingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitmen adı zorunludur")]
        [StringLength(100, ErrorMessage = "Eğitmen adı en fazla 100 karakter olabilir")]
        public string Trainer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [StringLength(200, ErrorMessage = "Konum en fazla 200 karakter olabilir")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Maksimum katılımcı sayısı zorunludur")]
        [Range(1, 1000, ErrorMessage = "Maksimum katılımcı sayısı 1-1000 arasında olmalıdır")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Eğitim maliyeti zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Eğitim maliyeti 0'dan büyük olmalıdır")]
        public decimal Cost { get; set; }
    }

    public class TrainingEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Eğitim başlığı zorunludur")]
        [StringLength(100, ErrorMessage = "Eğitim başlığı en fazla 100 karakter olabilir")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim açıklaması zorunludur")]
        [StringLength(1000, ErrorMessage = "Eğitim açıklaması en fazla 1000 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim türü zorunludur")]
        [StringLength(50, ErrorMessage = "Eğitim türü en fazla 50 karakter olabilir")]
        public string TrainingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitmen adı zorunludur")]
        [StringLength(100, ErrorMessage = "Eğitmen adı en fazla 100 karakter olabilir")]
        public string Trainer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [StringLength(200, ErrorMessage = "Konum en fazla 200 karakter olabilir")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Maksimum katılımcı sayısı zorunludur")]
        [Range(1, 1000, ErrorMessage = "Maksimum katılımcı sayısı 1-1000 arasında olmalıdır")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Eğitim maliyeti zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Eğitim maliyeti 0'dan büyük olmalıdır")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
} 