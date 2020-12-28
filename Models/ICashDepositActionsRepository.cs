﻿using System;
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
        CashDepositAction Update(CashDepositAction cashDepositActionChanges);
    }
}
