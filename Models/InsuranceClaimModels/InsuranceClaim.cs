using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsuranceClaim
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }      
        public string InsuranceCompany { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativePhone { get; set; }
        public string RepresentativeMail { get; set; }
        public string ClaimNo { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime ReportDate { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimStatus ClaimStatus { get; set; }
        public List<InsuranceClaimFile> InsuranceClaimFiles { get; set; }


    }
}
