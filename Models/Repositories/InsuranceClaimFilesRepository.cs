using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsuranceClaimFilesRepository : IInsuranceClaimFilesRepository
    {
        private readonly AppDbContext context;

        public InsuranceClaimFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public InsuranceClaimFile Add(InsuranceClaimFile file)
        {
            context.InsuranceClaimFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public InsuranceClaimFile GetFile(Guid id)
        {
            return context.InsuranceClaimFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }

        public List<InsuranceClaimFile> GetInsuranceClaimFiles(Guid id)
        {
            return context.InsuranceClaimFile.Where(file => file.InsuranceClaimId == id).ToList();
        }
    }
}
