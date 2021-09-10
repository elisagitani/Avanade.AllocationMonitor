using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Models
{
    public class EmployeeListViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }

        [DisplayName("Data di Nascita")]
        public string DataNascita { get; set; }
        public string Mansione { get; set; }
    }
}
