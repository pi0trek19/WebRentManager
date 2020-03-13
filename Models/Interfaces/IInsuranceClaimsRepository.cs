using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IInsuranceClaimsRepository
    {
        InsuranceClaim Add(InsuranceClaim claim);
        InsuranceClaim Edit(InsuranceClaim claimChanges);
        InsuranceClaim SetInProgress(InsuranceClaim claim);
        InsuranceClaim SetFinished(InsuranceClaim claim);
        InsuranceClaim GetClaim(Guid id);
        List<InsuranceClaim> GetAllCarClaims(Guid id); //id samochodu
        List<InsuranceClaim> GetAllClaims();
        
    }
}
