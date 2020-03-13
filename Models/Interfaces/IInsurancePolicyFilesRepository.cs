using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IInsurancePolicyFilesRepository
    {
        InsurancePolicyFile Add(InsurancePolicyFile file);
        InsurancePolicyFile GetFile(Guid id);
        List<InsurancePolicyFile> GetInsurancePolicyFiles(Guid id);
    }
}
