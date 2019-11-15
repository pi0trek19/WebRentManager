using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class HandoverDocumentsRepository : IHandoverDocumentsRepository
    {
        private readonly AppDbContext context;

        public HandoverDocumentsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public HandoverDocument Create(HandoverDocument document)
        {
            context.HandoverDocuments.Add(document);
            context.SaveChanges();
            return document;
        }

        public HandoverDocument GetHandoverById(Guid id)
        {
            return context.HandoverDocuments.Find(id);
        }

        public HandoverDocument GetHandoverByRent(Guid id)
        {
            return context.HandoverDocuments.FirstOrDefault(document => document.RentId == id);
        }

        public HandoverDocument Update(HandoverDocument documentChanges)
        {
            var document = context.HandoverDocuments.Attach(documentChanges);
            document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return documentChanges;
        }
    }
}
