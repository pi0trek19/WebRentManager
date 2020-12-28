using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CashDepositsRepository : ICashDepositsRepository
    {
        private readonly AppDbContext context;

        public CashDepositsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CashDeposit Add(CashDeposit deposit)
        {
            context.CashDeposits.Add(deposit);
            context.SaveChanges();
            return deposit;
        }

        public CashDeposit GetCashDeposit(Guid id)
        {
            return context.CashDeposits.Find(id);
        }

        public IEnumerable<CashDeposit> GetCashDeposits()
        {
            return context.CashDeposits;
        }

        public CashDeposit Update(CashDeposit depostitChanges)
        {
            var cashDeposit = context.CashDeposits.Attach(depostitChanges);
            cashDeposit.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return depostitChanges;
        }
    }
}
