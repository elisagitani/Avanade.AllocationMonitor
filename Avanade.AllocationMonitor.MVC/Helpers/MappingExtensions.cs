using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static EmployeeListViewModel ToEmployeeViewModel (this Dipendente employee)
        {
            return new EmployeeListViewModel
            {
                Id = employee.Id,
                Nome = employee.Nome,
                Cognome = employee.Cognome,
                Email = employee.Email,
                DataNascita = employee.DataNascita.ToString("dd/MM/yyyy"),
                Mansione = employee.Mansione
            };
        }

        public static IEnumerable<EmployeeListViewModel> ToEmployeeList(this IEnumerable<Dipendente> employees)
        {
            return employees.Select(t => t.ToEmployeeViewModel());
        }

        public static Dipendente ToEmployee(this EmployeeCreateViewModel employee)
        {
            return new Dipendente
            {
                Id = 0,
                Nome = employee.Nome,
                Cognome = employee.Cognome,
                Email = employee.Email,
                DataNascita = employee.DataNascita,
                Mansione = employee.Mansione,
                CostoOrario=employee.CostoOrario,
                DataInizioProfessione=employee.DataInizioProfessione
            };
        }

        public static EmployeeDetailsViewModel ToEmployeeDetails(this Dipendente employee)
        {
            return new EmployeeDetailsViewModel
            {   
                NomeCompleto = employee.Nome+" "+employee.Cognome,
                Email = employee.Email,
                DataDiNascita = employee.DataNascita.ToString("dd/MM/yyyy"),
                Mansione = employee.Mansione,
                CostoOrario = employee.CostoOrario,
                DataInizioProfessione = employee.DataInizioProfessione.ToString("dd/MM/yyyy")
            };
        }

        public static EmployeeEditViewModel ToEmployeeEdit(this Dipendente employee)
        {
            return new EmployeeEditViewModel
            {
                Id = employee.Id,
                Nome = employee.Nome,
                Cognome=employee.Cognome,
                DataNascita = employee.DataNascita,
                DataInizioProfessione = employee.DataInizioProfessione,
                Email = employee.Email,
                Mansione = employee.Mansione,
                CostoOrario = employee.CostoOrario,
               
            };
        }

        public static Dipendente ToEmployee(this EmployeeEditViewModel employee)
        {
            return new Dipendente
            {
                Id = employee.Id,
                Nome = employee.Nome,
                Cognome = employee.Cognome,
                DataNascita = employee.DataNascita,
                DataInizioProfessione = employee.DataInizioProfessione,
                Email = employee.Email,
                Mansione = employee.Mansione,
                CostoOrario = employee.CostoOrario,

            };
        }

    }
}
