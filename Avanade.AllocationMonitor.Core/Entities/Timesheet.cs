using Avanade.AllocationMonitor.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Timesheet : IEntity
    {
        public int? Id { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int OreAllocate { get; set; }

        [Required]
        public DateTime DataReport { get; set; }

        [Required]
        public virtual Attivita Attivita { get; set; }

        [Required]
        public virtual Dipendente Dipendente { get; set; }
    }
}
