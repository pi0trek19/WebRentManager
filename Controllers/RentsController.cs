using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class RentsController : Controller
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IRentsRepository _rentsRepository;
        private readonly IClientsRepository _clientsRepository;
        private readonly ICarDamagesRepository _carDamagesRepository;
        private readonly IMilageRecordsRepository _milageRecordsRepository;
        private readonly IHandoverDocumentsRepository _handoverDocumentsRepository;
        private ITemplateService _templateService;


        public RentsController(ICarsRepository carsRepository, IRentsRepository rentsRepository, IClientsRepository clientsRepository, 
            ICarDamagesRepository carDamagesRepository, IMilageRecordsRepository milageRecordsRepository, 
            IHandoverDocumentsRepository handoverDocumentsRepository, ITemplateService templateService)
        {
            _carsRepository = carsRepository;
            _rentsRepository = rentsRepository;
            _clientsRepository = clientsRepository;
            _carDamagesRepository = carDamagesRepository;
            _milageRecordsRepository = milageRecordsRepository;
            _handoverDocumentsRepository = handoverDocumentsRepository;
            _templateService = templateService;

        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = new List<Tuple<Car, Client, Rent>>();
            foreach (var item in _rentsRepository.GetAllRents())
            {
                Tuple<Car, Client, Rent> t1 = Tuple.Create(_carsRepository.GetCar(item.CarId), _clientsRepository.GetClient(item.ClientId), item);
                model.Add(t1);
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Reservations()
        {
            var model = new List<Tuple<Car, Client, Rent>>();
            foreach (var item in _rentsRepository.GetAllReservations())
            {
                Tuple<Car, Client, Rent> t1 = Tuple.Create(_carsRepository.GetCar(item.CarId), _clientsRepository.GetClient(item.ClientId), item);
                model.Add(t1);
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult FinishedRents()
        {
            var model = new List<Tuple<Car, Client, Rent>>();
            foreach (var item in _rentsRepository.GetAllFinished())
            {
                Tuple<Car, Client, Rent> t1 = Tuple.Create(_carsRepository.GetCar(item.CarId), _clientsRepository.GetClient(item.ClientId), item);
                model.Add(t1);
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Details(Guid id) // TODO dodać protokół i wyświetlić go na karcie
        {       
            Rent rent = _rentsRepository.GetRent(id);
            Guid carid = rent.CarId;
            Guid clientid = rent.ClientId;
            RentDetailsViewModel model = new RentDetailsViewModel
            {
                Rent = rent,
                Car = _carsRepository.GetCar(carid),
                Client = _clientsRepository.GetClient(clientid)
            };
            return View(model);
        }
        [HttpGet]
        public ViewResult AddRent()
        {
            RentAddRentViewModel model = new RentAddRentViewModel();
            model.Cars = _carsRepository.GetFreeCars().ToList();
            model.Clients = _clientsRepository.GetAllClients().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddRent(RentAddRentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Rent rent = new Rent
                {
                    CarId = model.CarId,
                    ClientId = model.ClientId,
                    StartDate = model.ProposedStartDate,
                    EndDate = model.EndDate,
                    RentFee = model.RentFee,
                    DamageFee = model.DamageFee,
                    MilageLimit = model.MilageLimit,
                    OverMilageFee = model.OverMilageFee,
                    TyresIncluded = model.TyresIncluded,
                    ServiceIncluded = model.ServiceIncluded,
                    AssistanceIncluded = model.AssistanceIncluded,
                    ReplacementCarIncluded = model.ReplacementCarIncluded,
                    IsEndDateSet = model.IsEndDateSet,
                    InitialPayment = model.InitialPayment,
                    UserName = model.UserName,
                    UserMail = model.UserMail,
                    UserPhone = model.UserPhone,
                    RentingCompany = model.RentingCompany,
                    RentType = model.RentType,
                    IsFinished = false,
                    IsActive = false,
                    Id = Guid.NewGuid()
                };
                Car car = _carsRepository.GetCar(model.CarId);
                car.IsReserved = true;
                car.ReservedUntil = model.ProposedStartDate.Date;
                _carsRepository.Update(car);
                _rentsRepository.Add(rent);
                return RedirectToAction("Reservations");
            }
            return RedirectToAction("AddRent");
        }
        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            Rent rent = _rentsRepository.GetRent(id);
            Client client = _clientsRepository.GetClient(rent.ClientId);
            Car car = _carsRepository.GetCar(rent.CarId);
            RentEditViewModel model = new RentEditViewModel
            {
                Id = rent.Id,
                Car = car,
                Client = client,
                AssistanceIncluded = rent.AssistanceIncluded,
                DamageFee = rent.DamageFee,
                EndDate = rent.EndDate,
                InitialPayment = rent.InitialPayment,
                IsEndDateSet = rent.IsEndDateSet,
                MilageLimit = rent.MilageLimit,
                OverMilageFee = rent.OverMilageFee,
                ProposedStartDate = rent.StartDate,
                RentFee = rent.RentFee,
                RentingCompany = rent.RentingCompany,
                RentType = rent.RentType,
                ReplacementCarIncluded = rent.ReplacementCarIncluded,
                ServiceIncluded = rent.ServiceIncluded,
                TyresIncluded = rent.TyresIncluded,
                UserMail = rent.UserMail,
                UserName = rent.UserName,
                UserPhone = rent.UserPhone
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(RentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Rent rent = _rentsRepository.GetRent(model.Id);
                rent.AssistanceIncluded = model.AssistanceIncluded;
                rent.DamageFee = model.DamageFee;
                rent.EndDate = model.EndDate;
                rent.InitialPayment = model.InitialPayment;
                rent.IsEndDateSet = model.IsEndDateSet;
                rent.MilageLimit = model.MilageLimit;
                rent.OverMilageFee = model.OverMilageFee;
                rent.StartDate = model.ProposedStartDate;
                rent.RentFee = model.RentFee;
                rent.RentingCompany = model.RentingCompany;
                rent.RentType = model.RentType;
                rent.ReplacementCarIncluded = model.ReplacementCarIncluded;
                rent.ServiceIncluded = model.ServiceIncluded;
                rent.TyresIncluded = model.TyresIncluded;
                rent.UserMail = model.UserMail;
                rent.UserName = model.UserName;
                rent.UserPhone = model.UserPhone;
                _rentsRepository.Update(rent);
                return RedirectToAction("details", new { id = model.Id });
            }
            return RedirectToAction("edit", new { id = model.Id });
        }
        [HttpGet]
        public ViewResult ChangeCar(Guid id)
        {
            Rent r1 = _rentsRepository.GetRent(id);
            List<Car> cars = _carsRepository.GetFreeCars().ToList();
            cars.Add(_carsRepository.GetCar(r1.CarId));
            RentChangeCarViewModel model = new RentChangeCarViewModel
            {
                CarId = r1.CarId,
                Cars = cars,
                Id = id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangeCar(RentChangeCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Rent rent = _rentsRepository.GetRent(model.Id);
                rent.CarId = model.CarId;
                return RedirectToAction("handoverstart", new { id = model.Id });
            }
            return RedirectToAction("ChangeCar", new { id = model.Id });
        }
        [HttpGet]
        public ViewResult HandoverStart(Guid id) //rent id 
        {
            Rent rent = _rentsRepository.GetRent(id);
            Car car = _carsRepository.GetCar(rent.CarId);
            List<CarDamage> carDamages = _carDamagesRepository.GetCarDamages(car.Id).ToList();
            Client client = _clientsRepository.GetClient(rent.ClientId);
            Guid[] guids = new Guid[50];
            for (int i = 0; i < guids.Length-1; i++)
            {
                guids[i] = Guid.NewGuid();
            }
            RentHandoverStartViewModel model = new RentHandoverStartViewModel
            {
                CarId = car.Id,
                CarReg = car.RegistrationNumber,
                CarDamages = carDamages,
                ClientId = client.Id,
                ClientName = client.Name,
                RentId = rent.Id,
                RentingCompany = rent.RentingCompany.ToString(),
                UserMail = rent.UserMail,
                UserName = rent.UserName,
                UserPhone = rent.UserPhone,
                Guids = guids,               
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult PopulateModal(Guid id)
        {
            CarDamage damage = _carDamagesRepository.GetCarDamage(id);
            RentPopulateModalViewModel model = new RentPopulateModalViewModel
            {
                DamageType=damage.DamageType.ToString(),
                Description=damage.Description
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
            double offsetx = Convert.ToDouble(split[0],provider);
            double offsety = Convert.ToDouble(split[1],provider);
            Guid id = new Guid(split[2]);
            Guid carId = new Guid(split[3]);
            string time = split[4];
            bool enddmg = true;
            if (time=="start")
            {
                enddmg = false;
            }
            Guid rentId = new Guid(split[5]);
            CarDamage damage = new CarDamage
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                Id = id,
                CarId = carId,
                RentId = rentId,
                IsEndDamage = enddmg,
                DateMarked = DateTime.Now,             
            };
            _carDamagesRepository.Add(damage);
            RentFormModalViewModel model = new RentFormModalViewModel
            {
                Id=id
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
        [HttpPost]
        public IActionResult HandoverStart(RentHandoverStartViewModel model)
        {
            if (ModelState.IsValid)
            {
                HandoverDocument document = new HandoverDocument //TODO Dodać podpisy
                {
                    CarId = model.CarId,
                    ClientId = model.ClientId,
                    IsTermAccepted = model.IsTermAccepted,
                    RentId = model.RentId,
                    StartDate = model.StartDate,
                    StartFireEx = model.StartFireEx,
                    StartFuel = model.StartFuel,
                    StartManual = model.StartManual,
                    StartMilage = model.StartMilage,
                    StartNotes = model.StartNotes,
                    StartRepairSet = model.StartRepairSet,
                    StartService = model.StartService,
                    StartSpare = model.StartSpare,
                    StartTriangle = model.StartSpare,
                    Id= Guid.NewGuid(),
                };
                _handoverDocumentsRepository.Create(document);
                //Dodanie do historii przebiegu
                MilageRecord record = new MilageRecord
                {
                    CarId = model.CarId,
                    Date = model.StartDate.Date,
                    Milage = model.StartMilage,
                    Id = Guid.NewGuid()
                };
                _milageRecordsRepository.Add(record);
                //Aktualizacja danych samochodu
                Car car = _carsRepository.GetCar(model.CarId);
                car.Milage = model.StartMilage;
                car.IsAvailable = false;
                car.IsReserved = false;
                _carsRepository.Update(car);
                //Aktualizacja danych wynajmu               
                Rent rent = _rentsRepository.GetRent(model.RentId);
                rent.IsActive = true;
                rent.StartDate = model.StartDate.Date;
                _rentsRepository.Update(rent);
                return RedirectToAction("Details", new { id = model.RentId });
            }
            //var dataUri = model.SignatureDataUrl;
            //var encodedImage = dataUri.Split(",")[1];
            //var decodedImage = Convert.FromBase64String(encodedImage);
            //System.IO.File.WriteAllBytes("signature.png", decodedImage);
            return RedirectToAction("HandoverStart", new {id = model.RentId });
        }
        public ViewResult HandoverEnd(Guid id)
        {
            Rent rent = _rentsRepository.GetRent(id);
            HandoverDocument document = _handoverDocumentsRepository.GetHandoverByRent(rent.Id);
            Client client = _clientsRepository.GetClient(rent.ClientId);
            Car car = _carsRepository.GetCar(rent.CarId);
            List<CarDamage> carDamages = _carDamagesRepository.GetCarDamages(car.Id).ToList();
            Guid[] guids = new Guid[50];
            for (int i = 0; i < guids.Length - 1; i++)
            {
                guids[i] = Guid.NewGuid();
            }
            RentHandoverEndViewModel model = new RentHandoverEndViewModel
            {
                Id = document.Id,
                CarId = car.Id,
                RentId = rent.Id,
                ClientId = client.Id,
                CarDamages = carDamages,
                CarReg = car.RegistrationNumber,
                ClientName = client.Name,
                Guids = guids,
                StartDate = rent.StartDate,
                StartFireEx = document.StartFireEx,
                StartFuel = document.StartFuel,
                StartManual = document.StartManual,
                StartMilage = document.StartMilage,
                StartNotes = document.StartNotes,
                StartRepairSet = document.StartRepairSet,
                StartService = document.StartService,
                StartSpare = document.StartSpare,
                StartTriangle = document.StartTriangle,
            };
            return View(model);
        }
    }
}