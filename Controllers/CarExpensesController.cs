using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class CarExpensesController : Controller
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ICarExpensesRepository _carExpensesRepository;

        public CarExpensesController(ICarsRepository carsRepository, ICarExpensesRepository carExpensesRepository)
        {
            _carsRepository = carsRepository;
            _carExpensesRepository = carExpensesRepository;
        }

        [HttpGet]
        public ViewResult AddExpense() //Guid id
        {
            CarExpenseAddViewModel model = new CarExpenseAddViewModel
            {
               // CarId = id,
               
            };
            return View(model); 
        }
        [HttpPost]
        public IActionResult AddExpense(CarExpenseAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                CarExpense expense = new CarExpense
                {
                    CarId = model.CarId,
                    CostCategory = model.CostCategory,
                    Decription = model.Decription,
                    Amount = model.Amount,
                    Date = model.Date,
                    Id = new Guid()
                };
                if (model.IsServiceSelected)
                {
                    expense.FacilityId = model.FacilityId;
                }
                _carExpensesRepository.Add(expense);
                return RedirectToAction("details", "cars", new { guid = model.CarId });
            }
            return RedirectToAction("addexpense", "carexpenses", new { id = model.CarId });
        }
    }
}
