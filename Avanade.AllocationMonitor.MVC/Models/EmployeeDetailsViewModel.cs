using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Models
{
    public class EmployeeDetailsViewModel
    {
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        [DisplayName("Data di Nascita")]
        public string DataDiNascita { get; set; }

        [DisplayName("Data inizio professione")]
        public string DataInizioProfessione { get; set; }
        [DisplayName("Costo Orario")]
        public double CostoOrario { get; set; }
        public string Mansione { get; set; }
        
    }
}
