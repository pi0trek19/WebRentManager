
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarExpensesRepository
    {
        CarExpense Add(CarExpense expense);
        CarExpense GetCarExpense(Guid id);
        IEnumerable<CarExpense> GetExpensesByCar(Guid id);
        CarExpense Update(CarExpense expenseChanges);

    }
}
