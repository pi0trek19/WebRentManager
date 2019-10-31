using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentDetailsViewModel
    {
        public Car Car { get; set; }
        public Client Client { get; set; }
        public Rent Rent { get; set; }
    }
}
