using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsurancePoliciesRepository : IInsurancePoliciesRepository
    {
        private readonly AppDbContext context;

        public InsurancePoliciesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public InsurancePolicy Add(InsurancePolicy policy)
        {
            context.InsurancePolicies.Add(policy);
            context.SaveChanges();
            return policy;
        }

        public InsurancePolicy GetActiveCarPolicy(Guid id)
        {
            return context.InsurancePolicies.FirstOrDefault(policy => (policy.CarId == id && policy.IsActive));
        }

        public List<InsurancePolicy> GetAllCarPolicies(Guid id)
        {
            return context.InsurancePolicies.Where(policy => policy.CarId == id).ToList();
        }

        public List<InsurancePolicy> GetAllPolcies()
        {
            return context.InsurancePolicies.ToList();
        }

        public InsurancePolicy GetPolicy(Guid id)
        {
            return context.InsurancePolicies.Find(id);
        }

        public InsurancePolicy Update(InsurancePolicy policy)
        {
            throw new NotImplementedException();
        }
    }
}
