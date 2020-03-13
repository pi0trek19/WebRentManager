using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class CarDetailsViewModel
    {
        public Car Car { get; set; }
        public bool IsCurrentlyRented { get; set; }
        //dane dla skończonych wynajmów - id klienta,nazwa klienta, użytkownik,tel,mail, od, do, przebieg start, przebieg koniec, id wynajmu
        public List<Tuple<Guid,string, string, string, string, DateTime, DateTime, Tuple<int, int,Guid>>> PreviousRents { get; set; }
        public Rent CurrentRent { get; set; }
        public string CurrentRentClientName { get; set; }
        public IEnumerable<InsuranceClaim> InsuranceClaims { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<TyreInfo> TyreInfos { get; set; }
        public IEnumerable<MilageRecord> MilageHistory { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
        public List<InsurancePolicy> PreviousInsurancePolicies { get; set; }
        public int DaysToNextService { get; set; }
        public int MilageToNextService { get; set; }
        public DateTime NextServiceDate { get; set; }
        public string PageTitle { get; set; }
    }
}
