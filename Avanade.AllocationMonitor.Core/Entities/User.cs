using Avanade.AllocationMonitor.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.Entities
{
    public class User: IEntity
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public bool IsAdministrator { get; set; }
    }
}