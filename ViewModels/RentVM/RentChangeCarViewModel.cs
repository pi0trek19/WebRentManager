using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentChangeCarViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Samochód")]
        public Guid CarId { get; set; }
        public List<Car> Cars { get; set; }
    }
}
