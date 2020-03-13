using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Income
    {
        public Guid Id { get; set; }
        public Guid? CarId { get; set; }
        public Car Car { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public IncomeType IncomeType { get; set; }
        public decimal Amount { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime Date { get; set; }
    }
}
