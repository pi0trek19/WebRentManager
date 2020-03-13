using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class IncomesRepository : IIncomesRepository
    {
        private readonly AppDbContext context;

        public IncomesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Income Add(Income income)
        {
            context.Incomes.Add(income);
            context.SaveChanges();
            return income;
        }

        public List<Income> GetAllByCar(Guid id)
        {
            return context.Incomes.Where(income => (income.Car!=null || income.CarId == id)).ToList();
        }

        public List<Income> GetAllByClient(Guid id)
        {
            return context.Incomes.Where(income => income.ClientId == id).ToList();
        }

        public List<Income> GetAllIncomes()
        {
            return context.Incomes.ToList();
        }

        public Income GetIncome(Guid id)
        {
            return context.Incomes.Find(id);
        }
    }
}
