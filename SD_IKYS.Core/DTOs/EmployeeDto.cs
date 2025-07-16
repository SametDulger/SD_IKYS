using System;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string TCKN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
    }

    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(11)]
        public string TCKN { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PlaceOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
    }
} 