using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsuranceClaimsRepository : IInsuranceClaimsRepository
    {
        private readonly AppDbContext context;

        public InsuranceClaimsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public InsuranceClaim Add(InsuranceClaim claim)
        {
            claim.ClaimStatus = ClaimStatus.Zgloszona;
            context.InsuranceClaims.Add(claim);
            context.SaveChanges();
            return claim;
        }

        public InsuranceClaim Edit(InsuranceClaim claimChanges)
        {
            throw new NotImplementedException();
        }

        public List<InsuranceClaim> GetAllCarClaims(Guid id)
        {
            return context.InsuranceClaims.Where(claim => claim.CarId == id).ToList();
        }

        public List<InsuranceClaim> GetAllClaims()
        {
            return context.InsuranceClaims.ToList();
        }

        public InsuranceClaim GetClaim(Guid id)
        {
            return context.InsuranceClaims.Find(id);
        }
        public InsuranceClaim SetFinished(InsuranceClaim claim)
        {
            throw new NotImplementedException();
        }

        public InsuranceClaim SetInProgress(InsuranceClaim claim)
        {
            throw new NotImplementedException();
        }

        public InsuranceClaim Update(InsuranceClaim claimChanges)
        {
            var claim = context.InsuranceClaims.Attach(claimChanges);
            claim.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return claimChanges;
        }
    }
}
