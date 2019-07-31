using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;

namespace WebRentManager.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsRepository _carsrepository;

        public CarsController(ICarsRepository _carsrepository)
        {
            this._carsrepository = _carsrepository;
        }
        public IActionResult List()
        {
            var model = _carsrepository.GetAllCars();
            return View(model);
        }
    }
}