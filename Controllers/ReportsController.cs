﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ICarsRepository _carsRepository;

        public ReportsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }
        [HttpGet]
        public ViewResult GeneralReport()
        {
            List<string> datatypes = new List<string>
            {
                "Samochody","Wynajmy","Klienci"
            };
            ReportsGeneralReportViewModel model = new ReportsGeneralReportViewModel();
            model.DropdownItems = datatypes;
            return View(model);
        }
        [HttpPost]
        public IActionResult GeneralReport(ReportsGeneralReportViewModel model)
        {
            switch (model.SelectedItem)
            {
                case "Samochody":
                    break;
                case "Wynajmy":
                    break;
                case "Klienci":
                    break;
            }
            return RedirectToAction("GeneralReport");
        }

        //[HttpGet]
        //public IActionResult DetailedReport()
        //{

        //}

        [HttpGet]
        public IActionResult Index()
        {
            List<CheckboxItem> items = new List<CheckboxItem>();
            foreach (var item in _carsRepository.GetAllCars())
            {
                CheckboxItem ent = new CheckboxItem
                {
                    Id = item.Id,
                    Name = item.RegistrationNumber,
                    Entity = "car",
                    Selected = false
                };
                items.Add(ent);
            }
            ReportsIndexViewModel model = new ReportsIndexViewModel
            {
                CheckboxItems = items
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ReportsIndexViewModel model)
        {
            List<Car> selected = new List<Car>();
            foreach (var item in model.CheckboxItems)
            {
                if (item.Selected && item.Entity=="car")
                {
                    selected.Add(_carsRepository.GetCar(item.Id));
                }
            }
            return RedirectToAction("index");
        }
    }
}