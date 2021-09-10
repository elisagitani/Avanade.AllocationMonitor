using Avanade.AllocationMonitor.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Attivita : IEntity
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        public int OrePreviste { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double FatturatoOrario { get; set; }

        [Required]
        public virtual Commessa Commessa { get; set; }
    }
}
