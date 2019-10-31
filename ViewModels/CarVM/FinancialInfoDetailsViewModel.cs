using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class FinancialInfoDetailsViewModel
    {
        public FinancialInfo Finfo { get; set; }
        public Car Car { get; set; }
    }
}
