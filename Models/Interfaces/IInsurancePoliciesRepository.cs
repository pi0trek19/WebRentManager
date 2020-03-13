using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IInsurancePoliciesRepository
    {
        InsurancePolicy Add(InsurancePolicy policy);
        InsurancePolicy GetPolicy(Guid id);
        InsurancePolicy GetActiveCarPolicy(Guid id);
        List<InsurancePolicy> GetAllCarPolicies(Guid id);
        List<InsurancePolicy> GetAllPolcies();
        InsurancePolicy Update(InsurancePolicy policy);

    }
}
