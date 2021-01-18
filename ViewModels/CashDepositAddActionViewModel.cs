using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class CashDepositAddActionViewModel
    {
        public Guid DepositId { get; set; }
        public decimal CurrentAmount { get; set; }
        [Required]
        [DisplayName("Data operacji")]
        public DateTime ActionDate { get; set; }
        public bool isPayment { get; set; }
        [DisplayName("Kwota operacji")]
        [Required]
        public decimal Amount { get; set; }
        [DisplayName("Numer dokumentu")]
        public string InvoiceNo { get; set; }
        [DisplayName("Opis operacji")]
        public string Description { get; set; }
    }
}
