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
        private readonly IFileDescriptionsRepository _fileDescriptionsRepository;
        private readonly IInsuranceClaimFilesRepository _insuranceClaimFilesRepository;

        public InsuranceClaimsController(IInsuranceClaimsRepository insuranceClaimsRepository, ICarsRepository carsRepository, IFileDescriptionsRepository fileDescriptionsRepository, IInsuranceClaimFilesRepository insuranceClaimFilesRepository)
        {
            _insuranceClaimsRepository = insuranceClaimsRepository;
            _carsRepository = carsRepository;
            _fileDescriptionsRepository = fileDescriptionsRepository;
            _insuranceClaimFilesRepository = insuranceClaimFilesRepository;
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
                return RedirectToAction("Details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("Create", new { id = model.CarId });
        }
        [HttpGet]
        public ViewResult Details(Guid id)
        {
            InsuranceClaim claim = _insuranceClaimsRepository.GetClaim(id);
            Car car = _carsRepository.GetCar(claim.CarId);
            InsuranceClaimDetailsViewModel model = new InsuranceClaimDetailsViewModel
            {
                Id = claim.Id,
                ClaimDate = claim.ClaimDate,
                ClaimNo = claim.ClaimNo,
                ClaimType = claim.ClaimType,
                ClaimStatus = claim.ClaimStatus,
                InsuranceCompany = claim.InsuranceCompany,
                ReportDate = claim.ReportDate,
                RepresentativeMail = claim.RepresentativeMail,
                RepresentativeName = claim.RepresentativeName,
                RepresentativePhone = claim.RepresentativePhone,
                CarReg = car.RegistrationNumber,
                CarId = car.Id
            };
            return View(model);
        }

        [HttpGet]
        public ViewResult AddClaimFile(Guid id)
        {
            InsuranceClaimsAddClaimFileViewModel model = new InsuranceClaimsAddClaimFileViewModel
            {
                Id = id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddClaimFile(InsuranceClaimsAddClaimFileViewModel model)
        {
            InsuranceClaim insuranceClaim = _insuranceClaimsRepository.GetClaim(model.Id);
            if (ModelState.IsValid)
            {
                FileHandler fileHandler = new FileHandler();
                FileDescription fileDescription = fileHandler.UploadSingleFile(model.File, model.FileType, insuranceClaim.ClaimNo, DateTime.Now, model.Descrption);
                _fileDescriptionsRepository.Create(fileDescription);
                InsuranceClaimFile claimFile = new InsuranceClaimFile
                {
                    FileDescriptionId = fileDescription.Id,
                    InsuranceClaimId = insuranceClaim.Id
                };
                _insuranceClaimFilesRepository.Add(claimFile);
                insuranceClaim.InsuranceClaimFiles.Add(claimFile);
                _insuranceClaimsRepository.Update(insuranceClaim);
                return RedirectToAction("details", new { id = model.Id });
            }
            return RedirectToAction("AddClaimFile", new { id = model.Id });
        }
    }
}