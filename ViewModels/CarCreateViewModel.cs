using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class CarCreateViewModel
    {
        [Required]
        [DisplayName("Nr rejestracyjny")]
        public string RegistrationNumber { get; set; }
        [Required]
        [DisplayName("Marka")]
        public string Make { get; set; }
        [Required]
        [DisplayName("Model")]
        public string Model { get; set; }
        [Required]
        [DisplayName("Rok produkcji")]        
        public int ProductionYear { get; set; }
    }
}
