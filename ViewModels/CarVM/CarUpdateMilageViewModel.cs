using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class CarUpdateMilageViewModel
    {
        public Guid CarId { get; set; }
        public string CarReg { get; set; }
        [DisplayName("Nowy przebieg")]
        [Required]
        public int Milage { get; set; }
        public DateTime Date { get; set; }
    }
}
