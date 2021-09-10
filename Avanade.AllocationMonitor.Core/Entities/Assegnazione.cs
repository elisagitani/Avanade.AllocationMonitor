using Avanade.AllocationMonitor.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Assegnazione: IEntity
    {
        public int? Id { get; set; }

        [Required]
        public virtual Dipendente Dipendente { get; set; }

        [Required]
        public virtual Attivita Attivita { get; set; }
    }
}
