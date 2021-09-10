using Avanade.AllocationMonitor.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Commessa : IEntity
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInizio { get; set; }

        [Required]
        public DateTime DataFineStimata { get; set; }

        public string Descrizione { get; set; }

        [Required]
        public virtual Cliente Cliente { get; set; }
    }
}
