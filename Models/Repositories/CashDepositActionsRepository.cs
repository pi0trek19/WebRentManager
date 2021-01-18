using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CashDepositActionsRepository : ICashDepositActionsRepository
    {
        private readonly AppDbContext context;

        public CashDepositActionsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CashDepositAction Add(CashDepositAction cashDepositAction)
        {
            context.CashDepositActions.Add(cashDepositAction);
            context.SaveChanges();
            return cashDepositAction;
        }

        public IEnumerable<CashDepositAction> GetActionsForDeposit(Guid id)
        {
            return context.CashDepositActions.Where(action => action.CashDepositId == id);
        }

        public IEnumerable<CashDepositAction> GetActionsForDepositBetweenDates(Guid id, DateTime from, DateTime to)
        {
            return context.CashDepositActions.Where(action => action.ActionDate >= from && action.ActionDate <= to && action.CashDepositId == id);
        }

        public CashDepositAction GetCashDepositAction(Guid id)
        {
            return context.CashDepositActions.Find(id);
        }


        public CashDepositAction Update(CashDepositAction cashDepositActionChanges)
        {
            var cashDepositAction = context.CashDepositActions.Attach(cashDepositActionChanges);
            cashDepositAction.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return cashDepositActionChanges;
        }
    }
}
