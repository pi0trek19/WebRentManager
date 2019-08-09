using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class ServiceFacilitiesController : Controller
    {
        private readonly IServiceFacilitiesRepository _serviceFacilitiesRepository;
        public ServiceFacilitiesController(IServiceFacilitiesRepository serviceFacilitiesRepository)
        {
            _serviceFacilitiesRepository = serviceFacilitiesRepository;
        }
        [HttpGet]
        public ViewResult Index(string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParam = sortOrder == "City" ? "city_desc" : "City";
            var model = _serviceFacilitiesRepository.GetAll();
            switch (sortOrder)
            {
                case "name_desc":
                    model = model.OrderByDescending(c => c.Name);
                    break;
                case "City":
                    model = model.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    model = model.OrderByDescending(s => s.City);
                    break;
                default:
                    model = model.OrderBy(s => s.Name);
                    break;
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceFacilityCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceFacility facility = new ServiceFacility
                {
                    City = viewModel.City,
                    Name = viewModel.Name,
                    ZipCode = viewModel.ZipCode,
                    Street = viewModel.Street,
                    Id = new Guid()
                };
                _serviceFacilitiesRepository.Add(facility);
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
