using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IFinancialInfosRepository
    {
        IEnumerable<FinancialInfo> GetAll();
        FinancialInfo GetFinancialInfo(Guid id);
        FinancialInfo GetCarFinancialInfo(Guid carId);
        FinancialInfo Add(FinancialInfo financialInfo);
        FinancialInfo Update(FinancialInfo financialInfoChanges);
        FinancialInfo Remove(FinancialInfo financialInfo);
    }
}
