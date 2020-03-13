using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public Car _Car { get; set; }
        public Client _ServiceFacility { get; set; }
        public Service _Service { get; set; }
    }
}
