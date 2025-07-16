using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
} 