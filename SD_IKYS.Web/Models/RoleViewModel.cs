using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Web.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
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