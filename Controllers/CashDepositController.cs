using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;
namespace WebRentManager.Controllers
{
    public class CashDepositController : Controller
    {
        private readonly ICashDepositActionsRepository _cashDepositActionsRepository;
        private readonly ICashDepositsRepository _cashDepositsRepository;

        public CashDepositController(ICashDepositActionsRepository cashDepositActionsRepository, ICashDepositsRepository cashDepositsRepository)
        {
            _cashDepositActionsRepository = cashDepositActionsRepository;
            _cashDepositsRepository = cashDepositsRepository;
        }

        //status kasy i 3 przyciski - wpłata, wypłata i aktualne saldo
        [HttpGet]
        public ViewResult Index()
        {           
            return View();
        }
        [HttpGet]
        public ViewResult DepositDetails(Guid id)
        {
            CashDeposit deposit = _cashDepositsRepository.GetCashDeposit(id);
            List<CashDepositAction> actions = _cashDepositActionsRepository.GetActionsForDeposit(id).ToList();
            var model = new CashDepositDetailsViewModel
            {
                Id = deposit.Id,
                CurrentAmount = deposit.CurrentAmount,
                Description = deposit.Description,
                Name = deposit.Name,
                DepositActions = actions
            };
            return View(model);
        }
        [HttpGet]
        public ViewResult AddDepositAction(Guid id)
        {
            var model = new CashDepositAddActionViewModel { DepositId = id };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddDepositAction(CashDepositAddActionViewModel model)
        {
            if (ModelState.IsValid)
            {

                CashDepositAction action = new CashDepositAction
                {
                    Id = Guid.NewGuid(),
                    isPayment = model.isPayment,
                    Amount = model.Amount,
                    InvoiceNo = model.InvoiceNo,
                    ActionDate = model.ActionDate,

                };
            }
            return RedirectToAction("Index");
        }
    }
}
