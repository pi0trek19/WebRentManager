using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class ClientCreateViewModel
    {
        [Required]
        [DisplayName("Typ klienta")]
        public ClientType ClientType { get; set; }
        [Required]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Miasto")]
        public string City { get; set; }
        [Required]
        [DisplayName("Kod pocztowy")]
        public string Zip { get; set; }
        /// <summary>
        /// NIP dla firmy i działalności, PESEL dla prywatnego
        /// </summary>
        [Required]
        [DisplayName("NIP/PESEL")]
        public string IdNumber1 { get; set; }
        /// <summary>
        /// KRS dla Firmy i działalności, nr dowodu dla prywatnego
        /// </summary>
        [DisplayName("KRS/Seria i numer dowodu")]
        public string IdNumber2 { get; set; }
        /// <summary>
        /// Tylko REGON dla firmy
        /// </summary>
        [DisplayName("REGON")]
        public string IdNumber3 { get; set; }
        [DisplayName("Osoba kontaktowa")]
        public string RepName { get; set; }
        [DisplayName("Adres e-mail")]
        [EmailAddress]
        public string RepMail { get; set; }
        [DisplayName("Nr telefonu")]
        public string RepPhone { get; set; }
    }
}
