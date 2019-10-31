using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentHandoverStartViewModel
    {
        //public Client Client { get; set; }
        //public Car Car { get; set; }
        //public List<CarDamage> CarDamages { get; set; }
        //public HandoverDocument Handover { get; set; }
        public int Xcoord { get; set; }
        public int Ycoord { get; set; }

    }
}
