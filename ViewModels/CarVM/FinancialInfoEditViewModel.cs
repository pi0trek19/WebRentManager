using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class FinancialInfoEditViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [DisplayName("Finansujący")]
        public string BankName { get; set; }
        [DisplayName("Typ finansowania")]
        public string LeaseType { get; set; }
        [DisplayName("Ilość miesięcy")]
        public int LeaseTime { get; set; }
        [DisplayName("Początek")]
        public DateTime LeaseStartDate { get; set; }
        [DisplayName("Koniec")]
        public DateTime LeaseEndDate { get; set; }
        [DisplayName("Wartość początkowa [netto]")]
        public decimal StartNetPrice { get; set; }
        [DisplayName("Wartość wykupu [netto]")]
        public decimal EndBuyoutNetPrice { get; set; }
        [DisplayName("Rata miesięczna [netto]")]
        public decimal MonthlyLeaseFee { get; set; }
        [DisplayName("Leasingobiorca")]
        [Required(ErrorMessage = "Nazwa leasingobiorcy jest wymagana")]
        public string Company { get; set; }
    }
}
