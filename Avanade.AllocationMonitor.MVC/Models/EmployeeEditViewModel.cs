using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Models
{
    public class EmployeeEditViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        [DisplayName("Data di nascita")]
        public DateTime DataNascita { get; set; }
        [DisplayName("Data inizio professione")]
        public DateTime DataInizioProfessione { get; set; }
        public string Email { get; set; }
        public string Mansione { get; set; }
        public List<SelectListItem> Mansioni { get; set; }
        [DisplayName("Costo Orario")]
        public double CostoOrario { get; set; } = 0;
    }
}
