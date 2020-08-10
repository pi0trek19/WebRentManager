using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class InsurancePoliciesController : Controller
    {
        private readonly IInsurancePoliciesRepository _insurancePoliciesRepository;
        private readonly ICarsRepository _carsRepository;

        public InsurancePoliciesController(IInsurancePoliciesRepository insurancePoliciesRepository, ICarsRepository carsRepository)
        {
            _insurancePoliciesRepository = insurancePoliciesRepository;
            _carsRepository = carsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create(Guid id) //id samochodu
        {
            InsurancePolicyCreateViewModel model = new InsurancePolicyCreateViewModel
            {
                CarId = id,
                Car = _carsRepository.GetCar(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(InsurancePolicyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                InsurancePolicy policy = new InsurancePolicy
                {
                    CarId = model.CarId,
                    Id = Guid.NewGuid(),
                    ValidFrom = model.ValidFrom,
                    ValidTo = model.ValidTo,
                    InsuranceCompany = model.InsuranceCompany,
                    Number = model.Number,
                    Cost = model.Cost,
                };
                if (DateTime.Now>model.ValidFrom)
                {
                    policy.IsActive = true;
                }
                _insurancePoliciesRepository.Add(policy);
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("create", new { id = model.CarId });
        }
        [HttpGet]
        public ViewResult Details(Guid id)
        {
            var model = _insurancePoliciesRepository.GetPolicy(id);
            model.Car = _carsRepository.GetCar(model.CarId);
            return View(model);
        }

    }
}