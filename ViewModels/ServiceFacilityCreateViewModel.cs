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
        [Required]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Kod Pocztowy")]
        [RegularExpression(@"[0-9][0-9]-[0-9][0-9][0-9]",
         ErrorMessage = "Błędny format kodu pocztowego")]
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Miasto")]
        public string City { get; set; }
    }
}
