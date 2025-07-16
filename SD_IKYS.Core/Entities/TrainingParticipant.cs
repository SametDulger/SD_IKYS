using System;

namespace SD_IKYS.Core.Entities
{
    public class TrainingParticipant : BaseEntity
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
        public decimal? Score { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string CertificateNumber { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public virtual Training Training { get; set; }
        public virtual Employee Employee { get; set; }
    }
} 