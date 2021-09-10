using Avanade.AllocationMonitor.Core.Entities.Common;
using Avanade.AllocationMonitor.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Cliente : IEntity
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Citta { get; set; }

        [Required]
        [StringLength(255)]
        public string Regione { get; set; }

        [Required]
        [StringLength(255)]
        public string Provincia { get; set; }

        [Required]
        public DimensioneAzienda Dimensione { get; set; }

        [StringLength(255)]
        public string NomeRiferimento { get; set; }

        [StringLength(255)]
        public string EmailRiferimento { get; set; }
    }
}
