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

        public CarsController(ICarsRepository _carsrepository)
        {
            this._carsrepository = _carsrepository;
        }
        public ViewResult List()
        {
            var model = _carsrepository.GetAllCars();
            return View(model);
        }

        public ViewResult Details(Guid guid)
        {
            Car car = _carsrepository.GetCar(guid);
            CarDetailsViewModel carDetailsViewModel = new CarDetailsViewModel()
            {
                Car = car,
                PageTitle = "Szczegóły " + car.RegistrationNumber
            };
            return View(carDetailsViewModel);
        }
        
    }
}