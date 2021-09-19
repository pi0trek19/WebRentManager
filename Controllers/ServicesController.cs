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
        private readonly IFileDescriptionsRepository _fileDescriptionsRepository;
        private readonly IServiceFilesRepository _serviceFilesRepository;

        public ServicesController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, IClientsRepository clientsRepository, IMilageRecordsRepository milageRecordsRepository, IInvoicesRepository invoicesRepository, IFileDescriptionsRepository fileDescriptionsRepository, IServiceFilesRepository serviceFilesRepository)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _clientsRepository = clientsRepository;
            _milageRecordsRepository = milageRecordsRepository;
            _invoicesRepository = invoicesRepository;
            _fileDescriptionsRepository = fileDescriptionsRepository;
            _serviceFilesRepository = serviceFilesRepository;
        }

        public ViewResult Index()
        {
            List <Service> services = _sevicesRepository.GetAll().ToList();

            foreach (var item in services)
            {
                item.Car = _carsrepository.GetCar(item.CarId);
                item.Client = _clientsRepository.GetClient(item.ClientId);
                //item.Invoice = _invoicesRepository.GetInvoice(item.InvoiceId);
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
                Car car = _carsrepository.GetCar(model.CarId);
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
                MilageRecord record = new MilageRecord
                {
                    CarId = service.CarId,
                    Date = service.Date,
                    Milage = service.Milage,
                    Id = Guid.NewGuid()
                };                
                Guid fileid = Guid.Empty;
                //if (model.IsInvoiceAdded)
                //{
                //    FileHandler fileHandler = new FileHandler();
                //    FileDescription fileDescription = fileHandler.UploadSingleFile(model.File, FileType.Serwis, car.RegistrationNumber,model.Date);
                //    _fileDescriptionsRepository.Create(fileDescription);                    
                //    Invoice invoice = new Invoice
                //    {
                //        Id = Guid.NewGuid(),
                //        Number = model.Number,
                //        Date = model.Date,
                //        Amount = model.Cost,
                //        ClientId = model.ServiceFacilityId,
                //        InvoiceType = InvoiceType.Koszt,
                //        FileDescriptionId=fileDescription.Id
                //    };
                //    _invoicesRepository.Add(invoice);
                //    service.InvoiceId = invoice.Id;
                //    fileid = fileDescription.Id;
                //}

                car.Milage = model.Milage;
                car.NextServiceMilage = model.Milage + car.ServiceInterval;
                _carsrepository.Update(car);
                _sevicesRepository.Add(service);
                _milageRecordsRepository.Add(record);
                if (model.IsInvoiceAdded)
                {
                    ServiceFile serviceFile = new ServiceFile
                    {
                        ServiceId = service.Id,
                        FileDescriptionId = fileid
                    };
                    _serviceFilesRepository.Add(serviceFile);
                }
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("addservice", "services", new { id = model.CarId });
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
                //service.InvoiceId = invoice.Id;
                _sevicesRepository.Upadate(service);
                return RedirectToAction("details", "services", new { id = model.ServiceId });
            }
            return RedirectToAction("AddServiceInvoice", "services", new { id = model.ServiceId });
        }

    }
        
}