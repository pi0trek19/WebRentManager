using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebRentManager.Controllers
{
    public class RentsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}