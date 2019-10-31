using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ICarsRepository _carsrepository;
        private readonly IServicesRepository _sevicesRepository;
        private readonly IServiceFacilitiesRepository _serviceFacilitiesRepository;
        private readonly ICarExpensesRepository _carExpensesRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ServicesController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, IServiceFacilitiesRepository serviceFacilitiesRepository, ICarExpensesRepository carExpensesRepository, IHostingEnvironment hostingEnvironment)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _serviceFacilitiesRepository = serviceFacilitiesRepository;
            _carExpensesRepository = carExpensesRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            List <Service> services = _sevicesRepository.GetAll().ToList();

            foreach (var item in services)
            {
                item.Car = _carsrepository.GetCar(item.CarId);
                item.ServiceFacility = _serviceFacilitiesRepository.GetServiceFacility(item.ServiceFacilityId);
            }
            return View(services);
        }

        public ViewResult Details(Guid guid)
        {
            Service service = _sevicesRepository.GetService(guid);
            ServiceDetailsViewModel viewModel = new ServiceDetailsViewModel
            {
                _Service = service,
                _Car = _carsrepository.GetCar(service.CarId),
                _ServiceFacility = _serviceFacilitiesRepository.GetServiceFacility(service.ServiceFacilityId)
            };
            return View(viewModel);
        }
        [HttpGet]
        public ViewResult AddService(Guid guid)
        {
            IEnumerable<ServiceFacility> facilities = _serviceFacilitiesRepository.GetAll();

            Car car = _carsrepository.GetCar(guid);
            AddServiceViewModel viewModel = new AddServiceViewModel()
            {
                ServiceFacilities = facilities.ToList(),
                Car = car,

            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddService(AddServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Invoice != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "carfiles");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Invoice.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    viewModel.Invoice.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Service service = new Service
                {
                    CarId = viewModel.CarId,
                    ServiceFacilityId = viewModel.ServiceFacilityId,
                    Milage = viewModel.Milage,
                    Date = viewModel.Date,
                    ServiceType = viewModel.ServiceType,
                    InvoicePath=uniqueFileName,
                    Id = new Guid()
                };
                _sevicesRepository.Add(service);
                CarExpense expense = new CarExpense
                {
                    CarId = viewModel.CarId,
                    Amount = viewModel.Cost,
                    Date = viewModel.Date,
                    FacilityId = viewModel.ServiceFacilityId,
                    Id = new Guid(),
                };
                if (service.ServiceType == ServiceType.Przegląd)
                {
                    expense.CostCategory = CostCategory.Przegląd;
                }
                else expense.CostCategory = CostCategory.Serwis;

                _carExpensesRepository.Add(expense);
                return RedirectToAction("details", "cars", new { guid = viewModel.CarId });
            }
            return RedirectToAction("addservice", "services", new { guid = viewModel.CarId });
        }
    }
        
}