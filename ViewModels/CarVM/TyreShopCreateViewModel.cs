using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class TyreShopCreateViewModel
    {
        [Required(ErrorMessage ="Pole Nazwa jest wymagane")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Ulica jest wymagane")]
        [DisplayName("Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole Miasto jest wymagane")]
        [DisplayName("Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole Kod pocztowy jest wymagane")]
        [DisplayName("Kod pocztowy")]
        [RegularExpression(@"[0-9][0-9]-[0-9][0-9][0-9]",
         ErrorMessage = "Błędny format kodu pocztowego")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Pole Numer telefonu jest wymagane")]
        [DisplayName("Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Pole Czynne Pn-Pt jest wymagane")]
        [DisplayName("Czynne Pn-Pt")]
        public string WeekHours { get; set; }

        [DisplayName("Czynne Sob")]
        public string SaturdayHours { get; set; }

        [DisplayName("Czynne Nd")]
        public string SundayHours { get; set; }
    }
}
