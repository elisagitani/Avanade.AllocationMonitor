using Avanade.AllocationMonitor.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Dipendente : IEntity
    {
        public int? Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascita { get; set; }

        [Required]
        public DateTime DataInizioProfessione { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double CostoOrario { get; set; }

        //[Required]
        public virtual string Mansione { get; set; }
    }
}
