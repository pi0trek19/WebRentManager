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
        private readonly ITyreInfosRepository _tyreInfosRepository;
        private readonly ITyreShopsRepository _tyreShopsRepository;
        private readonly IFinancialInfosRepository _financialInfosRepository;
        private readonly IMilageRecordsRepository _milageRecordsRepository;

        public CarsController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, IServiceFacilitiesRepository serviceFacilitiesRepository, ITyreInfosRepository tyreInfosRepository, ITyreShopsRepository tyreShopsRepository, IFinancialInfosRepository financialInfosRepository, IMilageRecordsRepository milageRecordsRepository)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _serviceFacilitiesRepository = serviceFacilitiesRepository;
            _tyreInfosRepository = tyreInfosRepository;
            _tyreShopsRepository = tyreShopsRepository;
            _financialInfosRepository = financialInfosRepository;
            _milageRecordsRepository = milageRecordsRepository;
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
            IEnumerable<TyreInfo> tyres = _tyreInfosRepository.GetAllByCar(car.Id);
            foreach (var item in tyres)
            {
                if (item.TyreShopId!=Guid.Empty)
                {
                    item.TyreShop = _tyreShopsRepository.GetTyreShop(item.TyreShopId);
                }
                else
                {
                    item.TyreShop = null;
                }
            }
            FinancialInfo financial = _financialInfosRepository.GetCarFinancialInfo(car.Id);
            IEnumerable<MilageRecord> records = _milageRecordsRepository.GetMilageRecordsByCar(car.Id);
            CarDetailsViewModel carDetailsViewModel = new CarDetailsViewModel()
            {
                FinancialInfo=financial,
                Car = car,
                Services = services,
                TyreInfos = tyres,
                MilageHistory=records,
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
        public ViewResult UpdateMilage(Guid guid)
        {
            CarUpdateMilageViewModel model = new CarUpdateMilageViewModel
            {
                CarId = guid,
                CarReg = _carsrepository.GetCar(guid).RegistrationNumber
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateMilage(CarUpdateMilageViewModel model)
        {
            if (ModelState.IsValid)
            {
                MilageRecord record = new MilageRecord
                {
                    CarId = model.CarId,
                    Milage = model.Milage,
                    Date = model.Date,
                    Id = new Guid()
                };
                _milageRecordsRepository.Add(record);
                Car car = _carsrepository.GetCar(model.CarId);
                car.Milage = model.Milage;
                _carsrepository.Update(car);
                return RedirectToAction("details", "cars", new { guid = model.CarId });
            }
            return RedirectToAction("Updatemilage", new { guid = model.CarId });
        }
    }
}