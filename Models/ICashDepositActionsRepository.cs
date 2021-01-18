using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICashDepositActionsRepository
    {
        CashDepositAction Add(CashDepositAction cashDepositAction);
        CashDepositAction GetCashDepositAction(Guid id);
        IEnumerable<CashDepositAction> GetActionsForDeposit(Guid id);
        IEnumerable<CashDepositAction> GetActionsForDepositBetweenDates(Guid id, DateTime from, DateTime to);
        CashDepositAction Update(CashDepositAction cashDepositActionChanges);
    }
}
