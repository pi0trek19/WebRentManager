using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;

namespace WebRentManager.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoicesRepository _invoicesRepository;

        public InvoicesController(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(Guid id)
        {
            var model = _invoicesRepository.GetInvoice(id);
            return View(model);
        }

    }
}