using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsurancePolicy
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal Cost { get; set; }
        public string Number { get; set; }
        public string InsuranceCompany { get; set; }
        public List<InsurancePolicyFile> InsurancePolicyFiles { get; set; }
    }
}
