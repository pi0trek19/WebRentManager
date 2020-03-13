using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IInsuranceClaimFilesRepository
    {
        InsuranceClaimFile Add(InsuranceClaimFile file);
        InsuranceClaimFile GetFile(Guid id);
        List<InsuranceClaimFile> GetInsuranceClaimFiles(Guid id);
    }
}
