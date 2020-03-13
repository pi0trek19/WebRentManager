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
        private readonly IClientsRepository _clientsRepository;
        private readonly IMilageRecordsRepository _milageRecordsRepository;
        private readonly IInvoicesRepository _invoicesRepository;

        public ServicesController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, IClientsRepository clientsRepository, IMilageRecordsRepository milageRecordsRepository, IInvoicesRepository invoicesRepository)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _clientsRepository = clientsRepository;
            _milageRecordsRepository = milageRecordsRepository;
            _invoicesRepository = invoicesRepository;
        }

        public ViewResult Index()
        {
            List <Service> services = _sevicesRepository.GetAll().ToList();

            foreach (var item in services)
            {
                item.Car = _carsrepository.GetCar(item.CarId);
                item.Client = _clientsRepository.GetClient(item.ClientId);
                item.Invoice = _invoicesRepository.GetInvoice(item.InvoiceId);
            }
            return View(services);
        }

        public ViewResult Details(Guid id)
        {
            Service service = _sevicesRepository.GetService(id);
            ServiceDetailsViewModel viewModel = new ServiceDetailsViewModel
            {
                _Service = service,
                _Car = _carsrepository.GetCar(service.CarId),
                _ServiceFacility = _clientsRepository.GetClient(service.ClientId)
            };
            return View(viewModel);
        }
        [HttpGet]
        public ViewResult AddService(Guid id)
        {
            List<Client> facilities = _clientsRepository.GetAllClients().ToList();

            Car car = _carsrepository.GetCar(id);
            AddServiceViewModel viewModel = new AddServiceViewModel()
            {
                ServiceFacilities = facilities,
                Car = car,

            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddService(AddServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Service service = new Service
                {
                    CarId = model.CarId,
                    ClientId = model.ServiceFacilityId,
                    Milage = model.Milage,
                    Date = model.Date,
                    ServiceType = model.ServiceType,
                    Cost=model.Cost,                    
                    Id = new Guid()
                };
                if (service.ServiceType==ServiceType.Przegląd)
                {
                    MilageRecord record = new MilageRecord
                    {
                        CarId = service.CarId,
                        Date = service.Date,
                        Milage = service.Milage,
                        Id = Guid.NewGuid()
                    };
                    _milageRecordsRepository.Add(record);
                }
                if (model.IsInvoiceAdded)
                {
                    //nie ma dodanego wrzucania pliku
                    Invoice invoice = new Invoice
                    {
                        Id = Guid.NewGuid(),
                        Number = model.Number,
                        Date = model.Date,
                        Amount = model.Cost,
                        ClientId = model.ServiceFacilityId,
                        InvoiceType = InvoiceType.Koszt
                    };
                    _invoicesRepository.Add(invoice);
                    service.InvoiceId = invoice.Id;
                }
                Car car = _carsrepository.GetCar(model.CarId);
                car.Milage = model.Milage;
                car.NextServiceMilage = model.Milage + car.ServiceInterval;
                _carsrepository.Update(car);
                _sevicesRepository.Add(service);
                return RedirectToAction("details", "cars", new { guid = model.CarId });
            }
            return RedirectToAction("addservice", "services", new { guid = model.CarId });
        }
        [HttpGet]
        public ViewResult AddServiceInvoice(Guid id) //id serwisu
        {
            ServiceAddInvoiceViewModel model = new ServiceAddInvoiceViewModel
            {
                ServiceId = id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddServiceInvoice(ServiceAddInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Service service = _sevicesRepository.GetService(model.ServiceId);
                Invoice invoice = new Invoice
                {
                    Id = Guid.NewGuid(),
                    Number = model.Number,
                    Date = service.Date,
                    Amount = service.Cost,
                    ClientId = service.ClientId,
                    InvoiceType = InvoiceType.Koszt
                };
                _invoicesRepository.Add(invoice);
                service.InvoiceId = invoice.Id;
                _sevicesRepository.Upadate(service);
                return RedirectToAction("details", "services", new { id = model.ServiceId });
            }
            return RedirectToAction("AddServiceInvoice", "services", new { id = model.ServiceId });
        }

    }
        
}