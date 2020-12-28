using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class CashDepositAddActionViewModel
    {
        public Guid DepositId { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime ActionDate { get; set; }
        public bool isPayment { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceNo { get; set; }
    }
}
