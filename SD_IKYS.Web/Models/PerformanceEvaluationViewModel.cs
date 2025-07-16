using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class PerformanceEvaluationViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public int EvaluatorId { get; set; }
        public string EvaluatorName { get; set; } = string.Empty;
        public DateTime EvaluationDate { get; set; }
        public string EvaluationPeriod { get; set; } = string.Empty;
        public int WorkQuality { get; set; }
        public int WorkQuantity { get; set; }
        public int Productivity { get; set; }
        public int Teamwork { get; set; }
        public int Communication { get; set; }
        public int Initiative { get; set; }
        public int ProblemSolving { get; set; }
        public int Attendance { get; set; }
        public int Punctuality { get; set; }
        public decimal OverallScore { get; set; }
        public string Strengths { get; set; } = string.Empty;
        public string AreasForImprovement { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class PerformanceEvaluationCreateViewModel
    {
        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Değerlendirici seçimi zorunludur")]
        public int EvaluatorId { get; set; }

        [Required(ErrorMessage = "Değerlendirme tarihi zorunludur")]
        public DateTime EvaluationDate { get; set; }

        [Required(ErrorMessage = "Değerlendirme dönemi zorunludur")]
        [StringLength(50, ErrorMessage = "Değerlendirme dönemi en fazla 50 karakter olabilir")]
        public string EvaluationPeriod { get; set; } = string.Empty;

        [Required(ErrorMessage = "İş kalitesi puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int WorkQuality { get; set; }

        [Required(ErrorMessage = "İş miktarı puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int WorkQuantity { get; set; }

        [Required(ErrorMessage = "Verimlilik puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Productivity { get; set; }

        [Required(ErrorMessage = "Takım çalışması puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Teamwork { get; set; }

        [Required(ErrorMessage = "İletişim puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Communication { get; set; }

        [Required(ErrorMessage = "İnisiyatif puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Initiative { get; set; }

        [Required(ErrorMessage = "Problem çözme puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int ProblemSolving { get; set; }

        [Required(ErrorMessage = "Devam puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Attendance { get; set; }

        [Required(ErrorMessage = "Zamanında gelme puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Punctuality { get; set; }

        [StringLength(500, ErrorMessage = "Güçlü yanlar en fazla 500 karakter olabilir")]
        public string Strengths { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Gelişim alanları en fazla 500 karakter olabilir")]
        public string AreasForImprovement { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Yorumlar en fazla 1000 karakter olabilir")]
        public string Comments { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Hedefler en fazla 500 karakter olabilir")]
        public string Goals { get; set; } = string.Empty;
    }

    public class PerformanceEvaluationEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Değerlendirici seçimi zorunludur")]
        public int EvaluatorId { get; set; }

        [Required(ErrorMessage = "Değerlendirme tarihi zorunludur")]
        public DateTime EvaluationDate { get; set; }

        [Required(ErrorMessage = "Değerlendirme dönemi zorunludur")]
        [StringLength(50, ErrorMessage = "Değerlendirme dönemi en fazla 50 karakter olabilir")]
        public string EvaluationPeriod { get; set; } = string.Empty;

        [Required(ErrorMessage = "İş kalitesi puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int WorkQuality { get; set; }

        [Required(ErrorMessage = "İş miktarı puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int WorkQuantity { get; set; }

        [Required(ErrorMessage = "Verimlilik puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Productivity { get; set; }

        [Required(ErrorMessage = "Takım çalışması puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Teamwork { get; set; }

        [Required(ErrorMessage = "İletişim puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Communication { get; set; }

        [Required(ErrorMessage = "İnisiyatif puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Initiative { get; set; }

        [Required(ErrorMessage = "Problem çözme puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int ProblemSolving { get; set; }

        [Required(ErrorMessage = "Devam puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Attendance { get; set; }

        [Required(ErrorMessage = "Zamanında gelme puanı zorunludur")]
        [Range(1, 5, ErrorMessage = "Puan 1-5 arasında olmalıdır")]
        public int Punctuality { get; set; }

        [StringLength(500, ErrorMessage = "Güçlü yanlar en fazla 500 karakter olabilir")]
        public string Strengths { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Gelişim alanları en fazla 500 karakter olabilir")]
        public string AreasForImprovement { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Yorumlar en fazla 1000 karakter olabilir")]
        public string Comments { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Hedefler en fazla 500 karakter olabilir")]
        public string Goals { get; set; } = string.Empty;

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; } = string.Empty;
    }

    public class TopPerformerViewModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public string Period { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }

    public class PerformanceReportViewModel
    {
        public int TotalEvaluations { get; set; }
        public decimal AverageScore { get; set; }
        public int HighPerformers { get; set; }
        public int ThisMonth { get; set; }
        public List<TopPerformerViewModel> TopPerformers { get; set; } = new List<TopPerformerViewModel>();
    }
} 