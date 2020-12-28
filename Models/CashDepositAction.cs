using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CashDepositAction
    {
        public Guid Id { get; set; }
        public Guid CashDepositId { get; set; }
        public DateTime ActionDate { get; set; }
        public bool isPayment { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountBeforeAction { get; set; }
        public decimal AmountAfterAction { get; set; }
        public string InvoiceNo { get; set; }

    }
}
