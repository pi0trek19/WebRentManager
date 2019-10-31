using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class ServiceFacilityCreateViewModel
    {
        [Required(ErrorMessage ="Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole Ulica jest wymagane")]
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Pole Kod Pocztowy jest wymagane")]
        [DisplayName("Kod Pocztowy")]
        [RegularExpression(@"[0-9][0-9]-[0-9][0-9][0-9]",
         ErrorMessage = "Błędny format kodu pocztowego")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Pole Miasto jest wymagane")]
        [DisplayName("Miasto")]
        public string City { get; set; }
    }
}
