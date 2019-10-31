using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class TyreShopDetailsViewModel
    {
        public List<Car> Cars { get; set; }
        public TyreShop TyreShop { get; set; }
    }
}
