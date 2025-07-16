using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Rol adı en fazla 50 karakter olabilir.")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Güncellenme Tarihi")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }

    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Rol adı zorunludur")]
        [StringLength(50, ErrorMessage = "Rol adı en fazla 50 karakter olabilir")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir")]
        public string Description { get; set; } = string.Empty;
    }

    public class RoleEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı zorunludur")]
        [StringLength(50, ErrorMessage = "Rol adı en fazla 50 karakter olabilir")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Açıklama en fazla 200 karakter olabilir")]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
} 