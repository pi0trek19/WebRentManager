using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InsurancePolicyFilesRepository : IInsurancePolicyFilesRepository
    {
        private readonly AppDbContext context;

        public InsurancePolicyFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public InsurancePolicyFile Add(InsurancePolicyFile file)
        {
            context.InsurancePolicyFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public InsurancePolicyFile GetFile(Guid id)
        {
            return context.InsurancePolicyFile.Find(id);
        }

        public List<InsurancePolicyFile> GetInsurancePolicyFiles(Guid id)
        {
            return context.InsurancePolicyFile.Where(file => file.InsurancePolicyId == id).ToList();
        }
    }
}
