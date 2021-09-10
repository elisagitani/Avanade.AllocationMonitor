using Avanade.AllocationMonitor.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class Mansione : IEntity
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
    }
}
