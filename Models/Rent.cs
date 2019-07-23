using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int DriverId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentFee { get; set; }
        public int DamageFee { get; set; }
        public int MilageLimit { get; set; }
        public decimal OverMilageFee { get; set; }
        public bool TyresIncluded { get; set; }
        public bool ServiceIncluded { get; set; }
        public bool AssistanceIncluded { get; set; }
        public bool ReplacementCarIncluded { get; set; }
        public bool FinanceIncluded { get; set; }

    }
}
