using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IRentsRepository _rentsRepository;
        private readonly ICarsRepository _carsRepository;

        public ClientsController(IClientsRepository clientsRepository, IRentsRepository rentsRepository, ICarsRepository carsRepository)
        {
            _clientsRepository = clientsRepository;
            _rentsRepository = rentsRepository;
            _carsRepository = carsRepository;
        }
        [HttpGet]
        public ViewResult Index()
        {
            var model = _clientsRepository.GetAllClients();
            return View(model);
        }
        [HttpGet]
        public ViewResult Details(Guid id)
        {
            Client client = _clientsRepository.GetClient(id);
            List<Tuple<Car, Rent>> activerents = new List<Tuple<Car, Rent>>();
            List<Tuple<Car, Rent>> finishedrents = new List<Tuple<Car, Rent>>();
            foreach (var rent in _rentsRepository.GetAllRentsByClient(id))
            {
                if (rent.IsFinished==true)
                {
                    Tuple<Car, Rent> tuple = Tuple.Create(_carsRepository.GetCar(rent.CarId), rent);
                    finishedrents.Add(tuple);
                }
                if (rent.IsActive==true&&rent.IsFinished==false)
                {
                    Tuple<Car, Rent> tuple = Tuple.Create(_carsRepository.GetCar(rent.CarId), rent);
                    activerents.Add(tuple);
                }
            }
            ClientDetailsViewModel model = new ClientDetailsViewModel
            {
                Client = client,
                ActiveRents = activerents,
                FinishedRents = finishedrents
            };
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ClientCreateViewModel model = new ClientCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ClientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    Name = model.Name,
                    Street = model.Street,
                    City = model.City,
                    Zip = model.Zip,
                    ClientType = model.ClientType,
                    IdNumber1 = model.IdNumber1,
                    IdNumber2 = model.IdNumber2,
                    IdNumber3 = model.IdNumber3,
                    RepName=model.RepName,
                    RepPhone=model.RepPhone,
                    RepMail=model.RepMail,
                    Id=new Guid()
                };
                _clientsRepository.Add(client);
                return RedirectToAction("details", new { id = client.Id });
            }
            return RedirectToAction("create");
                       
        }
        [HttpPost]
        public ViewResult Edit(Guid id)
        {
            Client client = _clientsRepository.GetClient(id);
            ClientEditViewModel model = new ClientEditViewModel
            {
                City = client.City,
                ClientType = client.ClientType,
                Id = client.Id,
                IdNumber1 = client.IdNumber1,
                IdNumber2 = client.IdNumber2,
                IdNumber3 = client.IdNumber3,
                Name = client.Name,
                RepMail = client.RepMail,
                RepName = client.RepName,
                RepPhone = client.RepPhone,
                Street = client.Street,
                Zip = client.Zip
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ClientEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client changed = _clientsRepository.GetClient(model.Id);
                changed.IdNumber1 = model.IdNumber1;
                changed.IdNumber2 = model.IdNumber2;
                changed.IdNumber3 = model.IdNumber3;
                changed.Name = model.Name;
                changed.RepMail = model.RepMail;
                changed.RepName = model.RepName;
                changed.RepPhone = model.RepPhone;
                changed.Street = model.Street;
                changed.Zip = model.Zip;
                _clientsRepository.Update(changed);
                return RedirectToAction("details", new { id = model.Id });
            }
            return RedirectToAction("edit", new { id = model.Id });
        }
    }
}
