using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentEditViewModel
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public Car Car { get; set; }
        [DisplayName("Typ wynajmu")]
        public RentType RentType { get; set; }
        [DisplayName("Planowana data wydania")]
        public DateTime ProposedStartDate { get; set; }
        [DisplayName("Koniec wynajmu")]
        public DateTime EndDate { get; set; }
        [DisplayName("Stawka wynajmu [netto]")]
        public decimal RentFee { get; set; }
        [DisplayName("Udział własny")]
        public int DamageFee { get; set; }
        [DisplayName("Limit przebiegu")]
        public int MilageLimit { get; set; }
        [DisplayName("Stawka za nadkilometr")]
        public decimal OverMilageFee { get; set; }
        [DisplayName("Opłata wstępna")]
        public decimal InitialPayment { get; set; }
        [DisplayName("Serwis wulkanizacyjny")]
        public bool TyresIncluded { get; set; }
        [DisplayName("Obsługa serwisowa")]
        public bool ServiceIncluded { get; set; }
        [DisplayName("Assistance")]
        public bool AssistanceIncluded { get; set; }
        [DisplayName("Samochód zastępczy")]
        public bool ReplacementCarIncluded { get; set; }
        [DisplayName("Użytkownik")]
        public string UserName { get; set; }
        [DisplayName("Nr telefonu")]
        public string UserPhone { get; set; }
        [DisplayName("Adres e-mail")]
        public string UserMail { get; set; }
        [DisplayName("Spółka fakturująca")]
        public RentingCompany RentingCompany { get; set; }
        [DisplayName("Czas nieokreślony")]
        public bool IsEndDateSet { get; set; }
    }
}
