using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICashDepositsRepository
    {
        CashDeposit Add(CashDeposit deposit);
        IEnumerable<CashDeposit> GetCashDeposits();
        CashDeposit GetCashDeposit(Guid id);
        CashDeposit Update(CashDeposit depostitChanges);
    }
}
