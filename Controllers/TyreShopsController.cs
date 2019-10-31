using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class TyreShopsController : Controller
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ITyreShopsRepository _tyreShopsRepository;
        private readonly ITyreInfosRepository _tyreInfosRepository;

        public TyreShopsController(ICarsRepository carsRepository, ITyreShopsRepository tyreShopsRepository, ITyreInfosRepository tyreInfosRepository)
        {
            _carsRepository = carsRepository;
            _tyreShopsRepository = tyreShopsRepository;
            _tyreInfosRepository = tyreInfosRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = _tyreShopsRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ViewResult Details(Guid guid)
        {
            List<Car> cars = _carsRepository.GetAllCars().ToList();
            List<Car> viewCars = new List<Car>();
            foreach (var car in cars)
            {
                car.TyreInfos = _tyreInfosRepository.GetAllByCar(car.Id).ToList();
                foreach (var ti in car.TyreInfos)
                {
                    if (ti.TyreShopId==guid)
                    {
                        ti.TyreShop = _tyreShopsRepository.GetTyreShop(guid);
                        car.TyreInfos.Add(ti);
                        viewCars.Add(car);
                    }
                }
            }
            TyreShopDetailsViewModel viewModel = new TyreShopDetailsViewModel
            {
                TyreShop = _tyreShopsRepository.GetTyreShop(guid),
                Cars = viewCars
            };
            return View(viewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TyreShopCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TyreShop shop = new TyreShop
                {
                    Name = viewModel.Name,
                    Street = viewModel.Street,
                    City = viewModel.City,
                    ZipCode = viewModel.ZipCode,
                    PhoneNumber = viewModel.PhoneNumber,
                    WeekHours = viewModel.WeekHours,
                    SaturdayHours = viewModel.SaturdayHours,
                    SundayHours = viewModel.SundayHours,
                    Id = new Guid()
                };
                _tyreShopsRepository.Add(shop);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
