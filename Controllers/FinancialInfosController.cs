using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class FinancialInfosController : Controller
    {
        private readonly IFinancialInfosRepository _financialInfosRepository;
        private readonly ICarsRepository _carsRepository;

        public FinancialInfosController(IFinancialInfosRepository fiancialInfosRepository, ICarsRepository carsRepository)
        {
            _financialInfosRepository = fiancialInfosRepository;
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = new List<Tuple<FinancialInfo, Car>>();
            foreach (var finfo in _financialInfosRepository.GetAll())
            {
                Tuple<FinancialInfo, Car> t1 = Tuple.Create(finfo, _carsRepository.GetCar(finfo.CarId));
                model.Add(t1);
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Details(Guid id)
        {
            FinancialInfo info = _financialInfosRepository.GetFinancialInfo(id);
            Car car = _carsRepository.GetCar(info.CarId);
            FinancialInfoDetailsViewModel model = new FinancialInfoDetailsViewModel
            {
                Finfo = info,
                Car = car
            };
            return View(model);
        }
        [HttpGet]
        public ViewResult Create(Guid carId)
        {
            FinancialInfoCreateViewModel model = new FinancialInfoCreateViewModel
            {
                CarId = carId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(FinancialInfoCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                FinancialInfo info = new FinancialInfo
                {
                    CarId = model.CarId,
                    BankName = model.BankName,
                    LeaseType = model.LeaseType,
                    LeaseTime = model.LeaseTime,
                    LeaseStartDate = model.LeaseStartDate,
                    LeaseEndDate = model.LeaseEndDate,
                    StartNetPrice = model.StartNetPrice,
                    EndBuyoutNetPrice = model.EndBuyoutNetPrice,
                    MonthlyLeaseFee = model.MonthlyLeaseFee,
                    Company = model.Company,
                    Id = new Guid()
                };
                _financialInfosRepository.Add(info);
                return RedirectToAction("Details", new { id = info.Id });
            }
            return RedirectToAction("Create", new { carId = model.CarId });
        }
        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            FinancialInfo info = _financialInfosRepository.GetFinancialInfo(id);
            FinancialInfoEditViewModel model = new FinancialInfoEditViewModel
            {
                Id = info.Id,
                CarId = info.CarId,
                BankName = info.BankName,
                LeaseType = info.LeaseType,
                LeaseTime = info.LeaseTime,
                LeaseStartDate = info.LeaseStartDate,
                LeaseEndDate = info.LeaseEndDate,
                StartNetPrice = info.StartNetPrice,
                EndBuyoutNetPrice = info.EndBuyoutNetPrice,
                MonthlyLeaseFee = info.MonthlyLeaseFee,
                Company = info.Company
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(FinancialInfoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                FinancialInfo info = _financialInfosRepository.GetFinancialInfo(model.Id);
                info.BankName = model.BankName;
                info.LeaseType = model.LeaseType;
                info.LeaseTime = model.LeaseTime;
                info.LeaseStartDate = model.LeaseStartDate;
                info.LeaseEndDate = model.LeaseEndDate;
                info.StartNetPrice = model.StartNetPrice;
                info.EndBuyoutNetPrice = model.EndBuyoutNetPrice;
                info.MonthlyLeaseFee = model.MonthlyLeaseFee;
                info.Company = model.Company;
                _financialInfosRepository.Update(info);
                return RedirectToAction("Details", new { id = info.Id });
            }
            return RedirectToAction("Edit", new { id = model.Id });
        }
        
    }
}
