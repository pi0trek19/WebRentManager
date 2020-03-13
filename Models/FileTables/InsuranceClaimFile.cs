using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsuranceClaimFile
    {
        public Guid InsuranceClaimId { get; set; }
        public InsuranceClaim InsuranceClaim { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
