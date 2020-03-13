using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IInvoicesRepository
    {
        Invoice Add(Invoice invoice);
        Invoice GetInvoice(Guid id);
        List<Invoice> GetAll();
        List<Invoice> GetAllByClient(Guid id);
        List<Invoice> GetAllCostByClient(Guid id);
        List<Invoice> GetAllIncomeByClient(Guid id);
        Invoice Update(Invoice invoice);

    }
}
