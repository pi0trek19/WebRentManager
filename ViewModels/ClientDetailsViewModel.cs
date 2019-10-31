using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public List<Tuple<Car,Rent>> ActiveRents { get; set; }
        public List<Tuple<Car,Rent>> FinishedRents { get; set; }
    }
}
