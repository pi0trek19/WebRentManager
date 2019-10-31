using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class FinancialInfosRepository : IFinancialInfosRepository
    {
        private readonly AppDbContext context;

        public FinancialInfosRepository(AppDbContext context)
        {
            this.context = context;
        }

        public FinancialInfo Add(FinancialInfo financialInfo)
        {
            context.FinancialInfos.Add(financialInfo);
            context.SaveChanges();
            return financialInfo;
        }

        public IEnumerable<FinancialInfo> GetAll()
        {
            return context.FinancialInfos;
        }

        public FinancialInfo GetCarFinancialInfo(Guid carId)
        {
            return context.FinancialInfos.FirstOrDefault(financialinfo => financialinfo.CarId == carId);
        }

        public FinancialInfo GetFinancialInfo(Guid id)
        {
            return context.FinancialInfos.Find(id);
        }

        public FinancialInfo Remove(FinancialInfo financialInfo)
        {
            throw new NotImplementedException();
        }

        public FinancialInfo Update(FinancialInfo financialInfoChanges)
        {
            var financialinfo = context.FinancialInfos.Attach(financialInfoChanges);
            financialinfo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return financialInfoChanges;
        }
    }
}
