using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Milage { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public ServiceType ServiceType { get; set; }
        public Car Car { get; set; }
        public Guid CarId { get; set; }
        public decimal Cost { get; set; }
//        public Guid InvoiceId { get; set; }
//        public Invoice Invoice { get; set; }
        public List<ServiceFile> ServiceFiles { get; set; }
    }
}
