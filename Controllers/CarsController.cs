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