using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentHandoverEndViewModel
    {
        public Guid Id { get; set; }
        public Guid RentId { get; set; }
        [Required]
        [DisplayName("Przebieg")]
        public int StartMilage { get; set; }
        [Required]
        [DisplayName("Ilość paliwa")]
        public int StartFuel { get; set; }
        [DisplayName("Uwagi")]
        public string StartNotes { get; set; }
        [DisplayName("Instrukcja")]
        public bool StartManual { get; set; }
        [DisplayName("Książka serwisowa")]
        public bool StartService { get; set; }
        [DisplayName("Trójkąt")]
        public bool StartTriangle { get; set; }
        [DisplayName("Gaśnica")]
        public bool StartFireEx { get; set; }
        [DisplayName("Koło zapasowe/dojazdowe")]
        public bool StartSpare { get; set; }
        [DisplayName("Zestaw naprawczy")]
        public bool StartRepairSet { get; set; }
        [Required]
        [DisplayName("Data i godzina wydania")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Przebieg")]
        public int EndMilage { get; set; }
        [Required]
        [DisplayName("Ilość paliwa")]
        public int EndFuel { get; set; }
        [DisplayName("Uwagi")]
        public string EndNotes { get; set; }
        [DisplayName("Instrukcja")]
        public bool EndManual { get; set; }
        [DisplayName("Książka serwisowa")]
        public bool EndService { get; set; }
        [DisplayName("Trójkąt")]
        public bool EndTriangle { get; set; }
        [DisplayName("Gaśnica")]
        public bool EndFireEx { get; set; }
        [DisplayName("Koło zapasowe/dojazdowe")]
        public bool EndSpare { get; set; }
        [DisplayName("Zestaw naprawczy")]
        public bool EndRepairSet { get; set; }
        [DisplayName("Data i godzina zwrotu")]
        public DateTime EndDate { get; set; }

        [DisplayName("Użytkownik")]
        public string UserName { get; set; }
        [DisplayName("Nr telefonu")]
        public string UserPhone { get; set; }
        [DisplayName("Adres e-mail")]
        public string UserMail { get; set; }
        public List<CarDamage> CarDamages { get; set; }
        public Guid[] Guids { get; set; }
        public Guid ClientId { get; set; }
        [DisplayName("Firma")]
        public string ClientName { get; set; }
        public Guid CarId { get; set; }
        [DisplayName("Nr rej")]
        public string CarReg { get; set; }
        public string RentingCompany { get; set; }
    }
}
