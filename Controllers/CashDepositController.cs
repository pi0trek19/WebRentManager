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
        [HttpGet]
        public ViewResult Index()
        {
            return View(_cashDepositsRepository.GetCashDeposits().ToList());
        }
        [HttpGet]
        public ViewResult GetReport(Guid id)
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
            var deposit = _cashDepositsRepository.GetCashDeposit(id);
            var model = new CashDepositAddActionViewModel 
            { 
                DepositId = id,
                CurrentAmount=deposit.CurrentAmount
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddDepositAction(CashDepositAddActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                decimal before = model.CurrentAmount;
                decimal after = 0.00m;
                if (model.isPayment)
                {
                     after = before - model.Amount;
                }
                else
                {
                     after = before + model.Amount;
                }
                CashDepositAction action = new CashDepositAction
                {
                    Id = Guid.NewGuid(),
                    isPayment = model.isPayment,
                    Amount = model.Amount,
                    InvoiceNo = model.InvoiceNo,
                    ActionDate = model.ActionDate,
                    AmountBeforeAction = before,
                    AmountAfterAction=after,
                    CashDepositId=model.DepositId,
                    Description=model.Description
                };
                CashDeposit deposit = _cashDepositsRepository.GetCashDeposit(model.DepositId);
                deposit.CurrentAmount = after;
                _cashDepositsRepository.Update(deposit);
                _cashDepositActionsRepository.Add(action);
                return RedirectToAction("DepositDetails", new { id = model.DepositId });
            }
            return RedirectToAction("Index");
        }
    }
}
