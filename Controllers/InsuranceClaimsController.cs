using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class InsuranceClaimsController : Controller
    {
        private readonly IInsuranceClaimsRepository _insuranceClaimsRepository;
        private readonly ICarsRepository _carsRepository;

        public InsuranceClaimsController(IInsuranceClaimsRepository insuranceClaimsRepository, ICarsRepository carsRepository)
        {
            _insuranceClaimsRepository = insuranceClaimsRepository;
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create(Guid id)
        {
            if (id != null)
            {
                var car = _carsRepository.GetCar(id);
                InsuranceClaimCreateViewModel model = new InsuranceClaimCreateViewModel { CarId = id, CarReg=car.RegistrationNumber };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(InsuranceClaimCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                InsuranceClaim claim = new InsuranceClaim
                {
                    Id = Guid.NewGuid(),
                    CarId = model.CarId,
                    InsuranceCompany = model.InsuranceCompany,
                    ReportDate=model.ReportDate,
                    ClaimDate=model.ClaimDate,
                    RepresentativeMail = model.RepresentativeMail,
                    RepresentativeName = model.RepresentativeName,
                    RepresentativePhone = model.RepresentativePhone,
                    ClaimNo = model.ClaimNo,
                    ClaimType = model.ClaimType,
                    ClaimStatus = ClaimStatus.Zgloszona
                };
                _insuranceClaimsRepository.Add(claim);
                return RedirectToAction("Details", "cars", new { guid = model.CarId });
            }
            return RedirectToAction("Create", new { id = model.CarId });
        }
    }
}