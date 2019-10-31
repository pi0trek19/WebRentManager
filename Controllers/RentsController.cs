using System;
using System.Collections.Generic;
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

        public RentsController(ICarsRepository carsRepository, IRentsRepository rentsRepository, IClientsRepository clientsRepository)
        {
            _carsRepository = carsRepository;
            _rentsRepository = rentsRepository;
            _clientsRepository = clientsRepository;
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
        public ViewResult Details(Guid id)
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
                    Id = new Guid()
                };
                //TODO zmiana statusu samochodu na zarezerwowany i ustawienie daty kiedy ma wyjechać
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
        public ViewResult HandoverStart() //Guid id
        {
            RentHandoverStartViewModel model = new RentHandoverStartViewModel();
            model.Xcoord = 467;
            model.Ycoord = 101;
            return View(model);
        }
        [HttpPost]
        public IActionResult HandoverStart(RentHandoverStartViewModel model)
        {
            //var dataUri = model.SignatureDataUrl;
            //var encodedImage = dataUri.Split(",")[1];
            //var decodedImage = Convert.FromBase64String(encodedImage);
            //System.IO.File.WriteAllBytes("signature.png", decodedImage);
            return Redirect("");
        }
    }
}