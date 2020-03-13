using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class HandoverDocumentFilesRepository : IHandoverDocumentFilesRepository
    {
        private readonly AppDbContext context;

        public HandoverDocumentFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public HandoverDocumentFile Add(HandoverDocumentFile file)
        {
            context.HandoverDocumentFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public HandoverDocumentFile GetFile(Guid id)
        {
            return context.HandoverDocumentFile.FirstOrDefault(file => file.FileDescriptionId == id);

        }

        public List<HandoverDocumentFile> GetHandoverDocumentFiles(Guid id)
        {
            return context.HandoverDocumentFile.Where(file => file.HandoverDocumentId == id).ToList();
        }
    }
}
