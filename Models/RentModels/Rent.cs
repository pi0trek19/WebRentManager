using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    /// <summary>
    /// Klasa reprezentująca wynajem
    /// </summary>
    public class Rent
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }
        public Guid HandoverDocumentId { get; set; }
        public RentType RentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentFee { get; set; }
        public int DamageFee { get; set; }
        public int MilageLimit { get; set; }
        public decimal OverMilageFee { get; set; }
        public decimal InitialPayment { get; set; }
        public bool TyresIncluded { get; set; }
        public bool ServiceIncluded { get; set; }
        public bool AssistanceIncluded { get; set; }
        public bool ReplacementCarIncluded { get; set; }
        /// <summary>
        /// True dla zakończonego, false dla trwającego
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// True jeżeli samochód został wydany
        /// </summary>
        public bool IsActive { get; set; }
        public bool IsEndDateSet { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserMail { get; set; }
        public RentingCompany RentingCompany { get; set; }
        public HandoverDocument HandoverDocument { get; set; }

        public List<RentFile> RentFiles { get; set; }
    }
}
