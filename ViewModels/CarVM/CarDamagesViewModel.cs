using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class CarDamagesViewModel
    {
        public List<CarDamage> CarDamages { get; set; }
        public Guid[] Guids { get; set; }
        public Guid CarId { get; set; }
    }
}
