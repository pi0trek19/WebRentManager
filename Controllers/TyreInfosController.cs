using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class TyreInfosController : Controller
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ITyreShopsRepository _tyreShopsRepository;
        private readonly ITyreInfosRepository _tyreInfosRepository;

        public TyreInfosController(ICarsRepository carsRepository, ITyreShopsRepository tyreShopsRepository, ITyreInfosRepository tyreInfosRepository)
        {
            _carsRepository = carsRepository;
            _tyreShopsRepository = tyreShopsRepository;
            _tyreInfosRepository = tyreInfosRepository;
        }
        [HttpGet]
        public ViewResult AddTyreInfo(Guid carId)
        {
            TyreInfoAddViewModel viewModel = new TyreInfoAddViewModel
            {
                CarId = carId,
                TyreShops = _tyreShopsRepository.GetAll().ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddTyreInfo(TyreInfoAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                TyreInfo info = new TyreInfo
                {
                    CarId = model.CarId,
                    TyreName = model.TyreName,                    
                    Diameter = model.Diameter,
                    Profile = model.Profile,
                    Width = model.Width,
                    SpeedIndex = model.SpeedIndex,
                    Dot = model.Dot,
                    TyreType = model.TyreType,
                    TyreStatus = model.TyreStatus,
                    Id=new Guid()
                };
                if (info.TyreStatus == TyreStatus.Samochód || info.TyreStatus == TyreStatus.Brak)
                {
                    info.TyreShopId = Guid.Empty;
                }
                else info.TyreShopId = model.TyreShopId;
                _tyreInfosRepository.Create(info);
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("addtyreinfo", new { carId = model.CarId });
        }
        [HttpGet]
        public ViewResult ChangeTyres(Guid carId)
        {
            TyreInfoChangeViewModel model = new TyreInfoChangeViewModel
            {
                CarId = carId,
                TyreShops = _tyreShopsRepository.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangeTyres(TyreInfoChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tyreinfos = _tyreInfosRepository.GetAllByCar(model.CarId).ToList();
                //będą tylko 2 lub mniej elementów z guid danego samochodu
                foreach (var item in tyreinfos)
                {
                    if (item.TyreStatus == TyreStatus.Samochód)
                    {
                        //opony z samochodu przechodzą do serwisu -> zmiana statusu i tyreshopid na wskazany z forma
                        item.TyreStatus = TyreStatus.Serwis;
                        item.TyreShopId = model.TyreShopId;                       
                    }
                    if (item.TyreStatus==TyreStatus.Serwis)
                    {
                        //opony z serwisu przechodzą na samochód - > zmiana statusu i tyreshopid jest empty
                        item.TyreStatus = TyreStatus.Samochód;
                        item.TyreShopId = Guid.Empty;
                    }
                    _tyreInfosRepository.Update(item);
                }
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("ChangeTyres", new { carId = model.CarId });
        }
        [HttpGet]
        public ViewResult Edit(Guid tyreInfoId)
        {
            var ty = _tyreInfosRepository.GetTyreInfo(tyreInfoId);
            TyreInfoEditViewModel model = new TyreInfoEditViewModel
            {
                Diameter=ty.Diameter,
                Dot=ty.Dot,
                Id=ty.Id,
                Profile=ty.Profile,
                TyreName=ty.TyreName,
                TyreType=ty.TyreType,
                Width=ty.Width,
                SpeedIndex=ty.SpeedIndex,                
                CarId=ty.CarId              
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(TyreInfoAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                TyreInfo tyreInfo = _tyreInfosRepository.GetTyreInfo(model.Id);
                tyreInfo.Profile = model.Profile;
                tyreInfo.SpeedIndex = model.SpeedIndex;
                tyreInfo.TyreName = model.TyreName;
                tyreInfo.TyreStatus = model.TyreStatus;
                tyreInfo.Width = model.Width;
                tyreInfo.Diameter = model.Diameter;
                tyreInfo.Dot = model.Dot;
                _tyreInfosRepository.Update(tyreInfo);
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("edit", new { tyreInfoId = model.Id });
        }
        [HttpGet]
        public ViewResult Relocate(Guid tyreInfoId)
        {
            TyreInfoRelocateViewModel model = new TyreInfoRelocateViewModel
            {
                Id = tyreInfoId,
                CarId = _tyreInfosRepository.GetTyreInfo(tyreInfoId).CarId,
                TyreShops = _tyreShopsRepository.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Relocate(TyreInfoRelocateViewModel model)
        {
            if (ModelState.IsValid)
            {
                TyreInfo tyreInfo = _tyreInfosRepository.GetTyreInfo(model.Id);
                tyreInfo.TyreShopId = model.NewTyreShopId;
                _tyreInfosRepository.Update(tyreInfo);
                return RedirectToAction("details", "cars", new { id = model.CarId });
            }
            return RedirectToAction("relocate", new { tyreInfoId = model.Id });
        }
    }
}
