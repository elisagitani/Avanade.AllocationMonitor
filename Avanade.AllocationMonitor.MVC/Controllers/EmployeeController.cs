using Avanade.AllocationMonitor.Core.BusinessLayers;
using Avanade.AllocationMonitor.Core.DependencyContainers;
using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.MVC.Helpers;
using Avanade.AllocationMonitor.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MainBusinessLayer mainBL;

        public EmployeeController()
        {

            mainBL = DependencyContainer.Resolve<MainBusinessLayer>();
            
        }
        public IActionResult Index()
        {
            var dipendenti = this.mainBL.FetchAllDipendenti();

            var model = dipendenti.ToEmployeeList();

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Mansioni=GetMansioni();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model==null)
            {
                ModelState.AddModelError("", "ERROR GENERATING MODEL");
                return View(model);
            }

            var employee = model.ToEmployee();
            var result = this.mainBL.CreateDipendente(employee);

            if (result.Count != 0)
            {
                ModelState.AddModelError("", "ERROR SAVING MODEL");
                return View(model);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Annulla()
        {
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return View();
            }

            var result = this.mainBL.GetDipendenteById(id);
            var model = result.ToEmployeeDetails();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View();

            // chiamata a BL ...
            var data = this.mainBL.GetDipendenteById(id);
            EmployeeDetailsViewModel model = data.ToEmployeeDetails();

            return View(model);
        }

        // HTTP POST /employee/delete/16
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id <= 0)
                return View();

            // chiamate al BL ...
            var data = this.mainBL.GetDipendenteById(id);
            var result = this.mainBL.DeleteDipendente(data);

            if (result.Count!=0)
            {
                return View("Error", null);
            } // in caso di errore

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            
                if (id <= 0)
                    return View();

                // chiamata a BL ...
                Dipendente data = this.mainBL.GetDipendenteById(id);
                EmployeeEditViewModel model = data.ToEmployeeEdit();
                ViewBag.Mansioni = GetMansioni();

                return View(model);
        }

            // HTTP POST /employee/edit/12
            [HttpPost]
            [ValidateAntiForgeryToken]
           
            public IActionResult Edit(int id, EmployeeEditViewModel model)
            {
                if (id != model.Id)
                {
                    ModelState.AddModelError(string.Empty, "Employee IDs do not match.");
                ViewBag.Mansioni = GetMansioni();
                return View(model);
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.Mansioni = GetMansioni();
                    return View(model);
                }

                if (model == null)
                {
                    ModelState.AddModelError(string.Empty, "Error Generating model.");
                    ViewBag.Mansioni = GetMansioni();
                    return View(model);
                }

                // chiamata al BL ...

                Dipendente updatedEmployee = model.ToEmployee();
                var result = this.mainBL.UpdateDipendente(updatedEmployee);

                if (result.Count!=0)
                {
                    ModelState.AddModelError(string.Empty, $"Error saving updated data");
                    ViewBag.Mansioni = GetMansioni();
                return View(model);
                } // in caso di errore

                return RedirectToAction(nameof(Index));
            }
        




        private List<SelectListItem> GetMansioni()
        {

            List<SelectListItem> listItem = new List<SelectListItem>();
            
                listItem.Add(new SelectListItem {Text = "Manager", Value = "Manager"});
                listItem.Add(new SelectListItem {Text = "Senior Consultant", Value = "Senior Consultant"});
                listItem.Add(new SelectListItem {Text = "Consultant", Value = "Consultant"});
                listItem.Add(new SelectListItem {Text = "Analyst", Value = "Analyst"});

            return listItem;
        }

    }
}
