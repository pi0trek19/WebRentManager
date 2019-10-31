using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarExpensesRepository : ICarExpensesRepository
    {
        private readonly AppDbContext context;

        public CarExpensesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CarExpense Add(CarExpense expense)
        {
            context.CarExpenses.Add(expense);
            context.SaveChanges();
            return expense;
        }

        public CarExpense GetCarExpense(Guid id)
        {
            return context.CarExpenses.Find(id);
        }

        public IEnumerable<CarExpense> GetExpensesByCar(Guid id)
        {
            return context.CarExpenses.Where(context => context.CarId == id);
        }

        public CarExpense Update(CarExpense expenseChanges)
        {
            var carexpense = context.CarExpenses.Attach(expenseChanges);
            carexpense.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return expenseChanges;
        }
    }
}
