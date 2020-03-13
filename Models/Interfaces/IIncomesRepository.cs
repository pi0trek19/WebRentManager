using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IIncomesRepository
    {
        Income Add(Income income);
        Income GetIncome(Guid id);
        List<Income> GetAllIncomes();
        List<Income> GetAllByClient(Guid id);
        List<Income> GetAllByCar(Guid id);

    }
}
