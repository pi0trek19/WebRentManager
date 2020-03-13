using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public InvoiceType InvoiceType { get; set; }

    }
}
