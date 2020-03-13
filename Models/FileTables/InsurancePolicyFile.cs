using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsurancePolicyFile
    {
        public Guid InsurancePolicyId { get; set; }
        public Guid FileDescriptionId { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
