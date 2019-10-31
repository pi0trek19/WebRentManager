using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class FinancialInfo
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string BankName { get; set; }
        public string LeaseType { get; set; }
        public int LeaseTime { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public decimal StartNetPrice { get; set; }
        public decimal EndBuyoutNetPrice { get; set; }
        public decimal MonthlyLeaseFee { get; set; }
        public string Company { get; set; }
    }
}
