using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsRepository _carsrepository;
        private readonly IServicesRepository _sevicesRepository;
        private readonly ITyreInfosRepository _tyreInfosRepository;
        private readonly ITyreShopsRepository _tyreShopsRepository;
        private readonly IFinancialInfosRepository _financialInfosRepository;
        private readonly IMilageRecordsRepository _milageRecordsRepository;
        private readonly ICarDamagesRepository _carDamagesRepository;
        private readonly IFileDescriptionsRepository _fileDescriptionsRepository;
        private readonly IRentsRepository _rentsRepository;
        private readonly IHandoverDocumentsRepository _handoverDocumentsRepository;
        private readonly IClientsRepository _clientsRepository;
        private readonly ICarFilesRepository _carFilesRepository;
        private readonly IInsurancePoliciesRepository _insurancePoliciesRepository;
        //testowe interfejsy do wyrzucenia po sprawdzeniu
        private readonly ITemplateService _templateService;
        private readonly IConverter _converter;

        public CarsController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, ITyreInfosRepository tyreInfosRepository, ITyreShopsRepository tyreShopsRepository, IFinancialInfosRepository financialInfosRepository, IMilageRecordsRepository milageRecordsRepository, ICarDamagesRepository carDamagesRepository, IFileDescriptionsRepository fileDescriptionsRepository, IRentsRepository rentsRepository, IHandoverDocumentsRepository handoverDocumentsRepository, IClientsRepository clientsRepository, ICarFilesRepository carFilesRepository, IInsurancePoliciesRepository insurancePoliciesRepository, ITemplateService templateService, IConverter converter)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _tyreInfosRepository = tyreInfosRepository;
            _tyreShopsRepository = tyreShopsRepository;
            _financialInfosRepository = financialInfosRepository;
            _milageRecordsRepository = milageRecordsRepository;
            _carDamagesRepository = carDamagesRepository;
            _fileDescriptionsRepository = fileDescriptionsRepository;
            _rentsRepository = rentsRepository;
            _handoverDocumentsRepository = handoverDocumentsRepository;
            _clientsRepository = clientsRepository;
            _carFilesRepository = carFilesRepository;
            _insurancePoliciesRepository = insurancePoliciesRepository;
            _templateService = templateService;
            _converter = converter;
        }

        public ViewResult List(string sortOrder)
        {
            ViewBag.RegSortParm = string.IsNullOrEmpty(sortOrder) ? "reg_desc" : "";
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
        public async Task<ActionResult> PDFAsync(Guid id)
        {
            List<CarDamage> carDamages = new List<CarDamage>();
            CarDamage damage = new CarDamage
            {
                OffsetX = 347,
                OffsetY = 374
            };
            carDamages = _carDamagesRepository.GetCarDamages(id).ToList();
            carDamages.Add(damage);
            HandoverPDFTemplateViewModel templateModel = new HandoverPDFTemplateViewModel
            {
                CarMake = "marka",
                CarModel = "model",
                CarReg = "rej",
                ClientName = "klient",
                UserMail = "user@mail",
                UserPhone = "userPh",
                CarDamages = carDamages
            };
            string templatedocument = await _templateService.RenderTemplateAsync("Templates/HandoverDocumentPDFTemplate", templateModel);
            var objectSettings = new ObjectSettings
            {
                HtmlContent = templatedocument,
                WebSettings = { DefaultEncoding = "utf-8"},
            };
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Test",
                //Out = @"C:\PDFCreator\Test.pdf"
            };
            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                
                Objects = { objectSettings }
            };

            var output = _converter.Convert(pdf);
            //var output = _converter.Convert(new HtmlToPdfDocument()
            //{
            //    GlobalSettings = new GlobalSettings
            //    {
            //        ColorMode = ColorMode.Color,
            //        Orientation = Orientation.Portrait,
            //        PaperSize = PaperKind.A4,
            //        Margins = new MarginSettings { Top = 10 },
            //        DocumentTitle = "Test",
            //        Out = @"C:\PDFCreator\Test.pdf"
            //    },
            //    Objects = {new ObjectSettings() { HtmlContent= templatedocument} },
            //}) ;

            return File(output,"application/pdf");

        }
        [HttpGet]
        public ViewResult HandoverDocumentPDFTemplate()
        {
            List<CarDamage> damages = new List<CarDamage>();
            HandoverPDFTemplateViewModel templateModel = new HandoverPDFTemplateViewModel
            {
                CarMake = "marka",
                CarModel = "model",
                CarReg = "rej",
                ClientName = "klient",
                UserMail = "user@mail",
                UserPhone = "userPh",                
                CarDamages=damages
            };
            return View("HandoverDocumentPDFTemplate", templateModel);
        }
        [HttpGet]        
        public ViewResult Details(Guid id)
        {
            //Task<IActionResult> task = Task.Run(async () => await PDFAsync());           
            
            Car car = _carsrepository.GetCar(id);
            //FileDescription file1 = new FileDescription
            //{
            //    Id = Guid.NewGuid(),
            //    Ext = ".jpg",
            //    Description = "test1",
            //    Enabled = true
            //};
            //FileDescription file2 = new FileDescription
            //{
            //    Id = Guid.NewGuid(),
            //    Ext = ".jpg",
            //    Description = "test2",
            //    Enabled = true
            //};
            //var file1car1 = new CarFile();
            //var file2car1 = new CarFile();
            //file1car1.Car = car;
            //file1car1.CarId = car.Id;
            //file1car1.FileDescription = file1;
            //file1car1.FileDescriptionId = file1.Id;

            //file2car1.Car = car;
            //file2car1.CarId = car.Id;
            //file2car1.FileDescription = file2;
            //file2car1.FileDescriptionId = file2.Id;
            //_fileDescriptionsRepository.Create(file1);
            //_fileDescriptionsRepository.Create(file2);
            //_carFilesRepository.Add(file1car1);
            //_carFilesRepository.Add(file2car1);


            //dane dla skończonych wynajmów - id klienta,nazwa klienta, użytkownik,tel,mail, od, do, przebieg start, przebieg koniec, id wynajmu
            List<Rent> rents = _rentsRepository.GetAllRentsByCar(id).ToList();
            Rent currentRent = null;
            var finishedRents = new List<Tuple<Guid,string, string, string, string, DateTime, DateTime, Tuple<int, int,Guid>>>();
            string clientName = "";
            if (rents!=null)
            {                
                foreach (var rent in rents)
                {
                    if (rent.IsFinished)
                    {
                        HandoverDocument document = _handoverDocumentsRepository.GetHandoverByRent(rent.Id);
                        var milage = Tuple.Create(document.StartMilage, document.EndMilage, rent.Id);
                        var finishedrent = new Tuple<Guid, string, string, string, string, DateTime, DateTime, Tuple<int, int, Guid>>
                            (rent.ClientId,_clientsRepository.GetClient(rent.ClientId).Name, rent.UserName, rent.UserPhone, rent.UserMail, rent.StartDate, rent.EndDate, milage);
                        finishedRents.Add(finishedrent);
                    }
                    else
                    {
                        if (rent.IsActive)
                        {
                            currentRent = rent;
                            clientName = _clientsRepository.GetClient(rent.ClientId).Name;
                        }
                    }
                    
                }
            }
            Service lastService = null;
            IEnumerable<Service> services = _sevicesRepository.GetAllbyCar(car.Id);
            if (services.Count()>0)
            {
                lastService = services.First();
                foreach (var item in services)
                {
                    item.Client = _clientsRepository.GetClient(item.ClientId);
                    if (item.Date>lastService.Date)
                    {
                        lastService = item;
                    }
                }
            }
            DateTime nextServiceDate = car.RegistrationDate.AddYears(car.YearsServiceInterval);
            int daysToNextService = (nextServiceDate -DateTime.Now.Date).Days;
            if (lastService!=null)
            {
                nextServiceDate = lastService.Date.AddYears(car.YearsServiceInterval);
                daysToNextService = (DateTime.Now.Date - nextServiceDate).Days;
            }
            int milageToNextService = car.NextServiceMilage - car.Milage;

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
            InsurancePolicy policy = _insurancePoliciesRepository.GetActiveCarPolicy(car.Id);
            List<InsurancePolicy> previousPolicies = new List<InsurancePolicy>();
            foreach (var item in _insurancePoliciesRepository.GetAllCarPolicies(car.Id))
            {
                if (!item.IsActive)
                {
                    previousPolicies.Add(item);
                }
            }
            CarDetailsViewModel carDetailsViewModel = new CarDetailsViewModel()
            {
                DaysToNextService = daysToNextService,
                NextServiceDate = nextServiceDate,
                MilageToNextService = milageToNextService,
                FinancialInfo = financial,
                Car = car,
                Services = services,
                TyreInfos = tyres,
                MilageHistory = records,
                PageTitle = "Szczegóły " + car.RegistrationNumber,
                IsCurrentlyRented = !car.IsAvailable,
                PreviousRents = finishedRents,
                CurrentRent = currentRent,
                CurrentRentClientName = clientName,
                InsurancePolicy = policy,
                PreviousInsurancePolicies = previousPolicies
            };
            return View(carDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Damages(Guid id)
        {
            Guid[] guids = new Guid[50];
            for (int i = 0; i < guids.Length - 1; i++)
            {
                guids[i] = Guid.NewGuid();
            }
            CarDamagesViewModel model = new CarDamagesViewModel
            {
                CarId = id,
                CarDamages = _carDamagesRepository.GetCarDamages(id).ToList(),
                Guids = guids
            };
                
            return View(model);
        }

        [HttpGet]
        public IActionResult PopulateModal(Guid id)
        {
            CarDamage damage = _carDamagesRepository.GetCarDamage(id);
            RentPopulateModalViewModel model = new RentPopulateModalViewModel
            {
                DamageType = damage.DamageType.ToString(),
                Description = damage.Description
            };
            return PartialView(model);
        }
        [HttpGet]
        public IActionResult FormModal(string routeValues)
        {
            string[] split = routeValues.Split(',');
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] { 3 };
            double offsetx = Convert.ToDouble(split[0], provider);
            double offsety = Convert.ToDouble(split[1], provider);
            Guid id = new Guid(split[2]);
            Guid carId = new Guid(split[3]);
            bool enddmg = false;
            CarDamage damage = new CarDamage
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                Id = id,
                CarId = carId,
                RentId = Guid.Empty,
                IsEndDamage = enddmg,
                DateMarked = DateTime.Now,
            };
            _carDamagesRepository.Add(damage);
            RentFormModalViewModel model = new RentFormModalViewModel
            {
                Id = id
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult PostModal(RentFormModalViewModel model)
        {
            if (ModelState.IsValid)
            {
                CarDamage damage = _carDamagesRepository.GetCarDamage(model.Id);
                damage.Description = model.Description;
                damage.DamageType = model.DamageType;
                _carDamagesRepository.Update(damage);
            }
            return PartialView("CloseModal");
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
                    Id = new Guid(),
                    IsAvailable = true,
                    IsReserved = false,
                    BodyType = viewModel.BodyType,
                    Color = viewModel.Color,
                    EngineSize = viewModel.EngineSize,
                    FuelType = viewModel.FuelType,
                    GearboxType = viewModel.GearboxType,
                    Milage = viewModel.Milage,
                    NextTechCheckDate = viewModel.RegistrationDate.AddYears(3),
                    PowerHP=viewModel.PowerHP,
                    PowerkW=viewModel.PowerkW,
                    RegistrationDate=viewModel.RegistrationDate,
                    ServiceInterval=viewModel.ServiceInterval,
                    SpecType=viewModel.SpecType,
                    VIN=viewModel.VIN,
                    NextServiceMilage=viewModel.ServiceInterval,                                       
                };
                _carsrepository.Add(newcar);
                return RedirectToAction("details", new { id = newcar.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult UpdateMilage(Guid id)
        {
            CarUpdateMilageViewModel model = new CarUpdateMilageViewModel
            {
                CarId = id,
                CarReg = _carsrepository.GetCar(id).RegistrationNumber
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
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("Updatemilage", new { id = model.CarId });
        }
        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            Car car = _carsrepository.GetCar(id);
            CarEditViewModel model = new CarEditViewModel
            {
                Id = car.Id,
                BodyType = car.BodyType,
                Color = car.Color,
                EngineSize = car.EngineSize,
                FuelType = car.FuelType,
                GearboxType = car.GearboxType,
                Make = car.Make,
                Model = car.Model,
                Milage = car.Milage,
                PowerHP = car.PowerHP,
                PowerkW = car.PowerkW,
                ProductionYear = car.ProductionYear,
                RegistrationDate = car.RegistrationDate,
                RegistrationNumber = car.RegistrationNumber,
                ServiceInterval = car.ServiceInterval,
                SpecType = car.SpecType,
                VIN = car.VIN
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CarEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carsrepository.GetCar(viewModel.Id);
                car.Id = viewModel.Id;
                car.BodyType = viewModel.BodyType;
                car.Color = viewModel.Color;
                car.EngineSize = viewModel.EngineSize;
                car.FuelType = viewModel.FuelType;
                car.GearboxType = viewModel.GearboxType;
                car.Make = viewModel.Make;
                car.Model = viewModel.Model;
                car.Milage = viewModel.Milage;
                car.PowerHP = viewModel.PowerHP;
                car.PowerkW = viewModel.PowerkW;
                car.ProductionYear = viewModel.ProductionYear;
                car.RegistrationDate = viewModel.RegistrationDate;
                car.RegistrationNumber = viewModel.RegistrationNumber;
                car.ServiceInterval = viewModel.ServiceInterval;
                car.SpecType = viewModel.SpecType;
                car.VIN = viewModel.VIN;
                _carsrepository.Update(car);
                return RedirectToAction("details", "cars", new { id = car.Id });
            }
            return RedirectToAction("edit", "cars", new { id = viewModel.Id });
        }
        [HttpGet]
        public ViewResult AddCarFile(Guid id)
        {
            return View();
        }
    }
}