using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class TyreInfoRelocateViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public List<TyreShop> TyreShops { get; set; }
        [DisplayName("Nowy serwis")]
        public Guid NewTyreShopId { get; set; }
    }
}
