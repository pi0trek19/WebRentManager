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
    public class ServicesController : Controller
    {
        private readonly ICarsRepository _carsrepository;
        private readonly IServicesRepository _sevicesRepository;
        private readonly IServiceFacilitiesRepository _serviceFacilitiesRepository;

        public ServicesController(ICarsRepository carsrepository, IServicesRepository sevicesRepository, IServiceFacilitiesRepository serviceFacilitiesRepository)
        {
            _carsrepository = carsrepository;
            _sevicesRepository = sevicesRepository;
            _serviceFacilitiesRepository = serviceFacilitiesRepository;
        }

        public ViewResult Index()
        {
            var model = _sevicesRepository.GetAll();
            return View(model);
        }

        public ViewResult Details(Guid guid)
        {
            Service service = _sevicesRepository.GetService(guid);
            ServiceDetailsViewModel viewModel = new ServiceDetailsViewModel
            {
                _Service = service,
                _Car = _carsrepository.GetCar(service.CarId),
                _ServiceFacility = _serviceFacilitiesRepository.GetServiceFacility(service.ServiceFacilityId)
            };
            return View(viewModel);
        }
    }
        
}