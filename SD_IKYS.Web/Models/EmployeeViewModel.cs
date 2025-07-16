using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string TCKN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public decimal? SalaryNullable { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "TCKN zorunludur")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TCKN 11 karakter olmalıdır")]
        public string TCKN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Orta ad en fazla 50 karakter olabilir")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public DateTime DateOfBirth { get; set; }
        public DateTime BirthDate { get; set; }

        [StringLength(100, ErrorMessage = "Doğum yeri en fazla 100 karakter olabilir")]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "İşe başlama tarihi zorunludur")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Pozisyon zorunludur")]
        [StringLength(50, ErrorMessage = "Pozisyon en fazla 50 karakter olabilir")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departman zorunludur")]
        [StringLength(50, ErrorMessage = "Departman en fazla 50 karakter olabilir")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Maaş zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Maaş 0'dan büyük olmalıdır")]
        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
    }

    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TCKN zorunludur")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TCKN 11 karakter olmalıdır")]
        public string TCKN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Orta ad en fazla 50 karakter olabilir")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public DateTime DateOfBirth { get; set; }
        public DateTime BirthDate { get; set; }

        [StringLength(100, ErrorMessage = "Doğum yeri en fazla 100 karakter olabilir")]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "İşe başlama tarihi zorunludur")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Pozisyon zorunludur")]
        [StringLength(50, ErrorMessage = "Pozisyon en fazla 50 karakter olabilir")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departman zorunludur")]
        [StringLength(50, ErrorMessage = "Departman en fazla 50 karakter olabilir")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Maaş zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Maaş 0'dan büyük olmalıdır")]
        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
    }
} 