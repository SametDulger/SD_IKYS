using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ApproverName { get; set; } = string.Empty;
        public DateTime? ApprovalDate { get; set; }
        public string Comments { get; set; } = string.Empty;
        public string ApprovalNotes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class LeaveRequestCreateViewModel
    {
        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İzin türü zorunludur")]
        [StringLength(50, ErrorMessage = "İzin türü en fazla 50 karakter olabilir")]
        public string LeaveType { get; set; } = string.Empty;

        [Required(ErrorMessage = "İzin nedeni zorunludur")]
        [StringLength(500, ErrorMessage = "İzin nedeni en fazla 500 karakter olabilir")]
        public string Reason { get; set; } = string.Empty;
    }

    public class LeaveRequestEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Personel seçimi zorunludur")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İzin türü zorunludur")]
        [StringLength(50, ErrorMessage = "İzin türü en fazla 50 karakter olabilir")]
        public string LeaveType { get; set; } = string.Empty;

        [Required(ErrorMessage = "İzin nedeni zorunludur")]
        [StringLength(500, ErrorMessage = "İzin nedeni en fazla 500 karakter olabilir")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Durum zorunludur")]
        public string Status { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Yorum en fazla 500 karakter olabilir")]
        public string Comments { get; set; } = string.Empty;
    }

    public class LeaveRequestApprovalViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
    }
} 