using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class TyreInfoChangeViewModel
    {
        public List<TyreShop> TyreShops { get; set; }
        [DisplayName("Serwis")]
        [Required(ErrorMessage ="Serwis musi być wybrany")]
        public Guid TyreShopId { get; set; }
        public Guid CarId { get; set; }

    }
}
