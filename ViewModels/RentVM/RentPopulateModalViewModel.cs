using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class RentPopulateModalViewModel
    {
        public string DamageType { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
