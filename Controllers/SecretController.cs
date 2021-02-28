using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebRentManager.Controllers
{
    public class SecretController : Controller
    {
        public IActionResult Everyone()
        {
            return View();
        }
        public IActionResult Logged()
        {
            return View();
        }
    }
}
