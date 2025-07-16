using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SD_IKYS.Core.Entities
{
    public class Training : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingType { get; set; } // Internal, External, Online, etc.

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(100)]
        public string Trainer { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public int MaxParticipants { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planned"; // Planned, InProgress, Completed, Cancelled

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<TrainingParticipant> Participants { get; set; }
    }
} 