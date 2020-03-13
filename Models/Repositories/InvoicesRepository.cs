using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly AppDbContext context;

        public InvoicesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Invoice Add(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return invoice;
        }

        public List<Invoice> GetAll()
        {
            return context.Invoices.ToList();
        }

        public List<Invoice> GetAllByClient(Guid id)
        {
            return context.Invoices.Where(invoice => invoice.ClientId == id).ToList();
        }

        public List<Invoice> GetAllCostByClient(Guid id)
        {
            return context.Invoices.Where(invoice => (invoice.ClientId == id && invoice.InvoiceType==InvoiceType.Koszt)).ToList();
        }

        public List<Invoice> GetAllIncomeByClient(Guid id)
        {
            return context.Invoices.Where(invoice => (invoice.ClientId == id && invoice.InvoiceType == InvoiceType.Przychód)).ToList();
        }

        public Invoice GetInvoice(Guid id)
        {
            return context.Invoices.Find(id);
        }

        public Invoice Update(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
