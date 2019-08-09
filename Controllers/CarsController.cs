using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsRepository _carsrepository;
        private readonly IServicesRepository _sevicesRepository;
        private readonly IServiceFacilitiesRepository _serviceFacilitiesRepository;

        public CarsController(ICarsRepository _carsrepository, IServicesRepository _sevicesRepository, IServiceFacilitiesRepository _serviceFacilitiesRepository)
        {
            this._carsrepository = _carsrepository;
            this._sevicesRepository = _sevicesRepository;
            this._serviceFacilitiesRepository = _serviceFacilitiesRepository;
        }
        public ViewResult List(string sortOrder)
        {
            ViewBag.RegSortParm = String.IsNullOrEmpty(sortOrder) ? "reg_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Prod_Date" ? "Prod_date_desc" : "Prod_Date";
            var model = _carsrepository.GetAllCars();
            switch (sortOrder)
            {
                case "reg_desc":
                    model = model.OrderByDescending(c => c.RegistrationNumber);
                    break;
                case "Prod_Date":
                    model = model.OrderBy(s => s.ProductionYear);
                    break;
                case "Prod_date_desc":
                    model = model.OrderByDescending(s => s.ProductionYear);
                    break;
                default:
                    model = model.OrderBy(s => s.RegistrationNumber);
                    break;
            }
            return View(model);
        }
        [HttpGet]        
        public ViewResult Details(Guid guid)
        {
            Car car = _carsrepository.GetCar(guid);
            IEnumerable<Service> services = _sevicesRepository.GetAllbyCar(car.Id);
            foreach (var item in services)
            {
                item.ServiceFacility = _serviceFacilitiesRepository.GetServiceFacility(item.ServiceFacilityId);
            }
            CarDetailsViewModel carDetailsViewModel = new CarDetailsViewModel()
            {
                Car = car,
                Services = services,
                PageTitle = "Szczegóły " + car.RegistrationNumber
            };
            return View(carDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Car newcar = new Car
                {
                    RegistrationNumber = viewModel.RegistrationNumber,
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    ProductionYear = viewModel.ProductionYear,
                    Id = new Guid()
                };
                _carsrepository.Add(newcar);
                return RedirectToAction("details", new { id = newcar.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult AddService(Guid guid)
        {
            IEnumerable<ServiceFacility> facilities = _serviceFacilitiesRepository.GetAll();

            Car car = _carsrepository.GetCar(guid);
            AddServiceViewModel viewModel = new AddServiceViewModel()
            {
                ServiceFacilities = facilities.ToList(),
                Car=car,
                
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddService(AddServiceViewModel viewModel)
        {
            Service service = new Service
            {
                CarId = viewModel.CarId,
                ServiceFacilityId =viewModel.ServiceFacilityId,
                Milage = viewModel.Milage,
                Date = viewModel.Date,
                ServiceType = ServiceType.Przegląd,
                Id = new Guid()
            };

            _sevicesRepository.Add(service);
            return RedirectToAction("details", "cars", new { id = viewModel.CarId });
            //if (ModelState.IsValid)
            //{
                
            //}
            //return RedirectToAction("addservice", "cars", viewModel.Car.Id);

        }
    }
}