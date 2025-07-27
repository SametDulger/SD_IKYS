using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string TCKN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
    }

    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
    }
} 