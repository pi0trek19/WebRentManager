using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class FileDescriptionsRepository : IFileDescriptionsRepository
    {
        private readonly AppDbContext context;

        public FileDescriptionsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public FileDescription Create(FileDescription file)
        {
            context.FileDescriptions.Add(file);
            context.SaveChanges();
            return file;
        }

        public FileDescription Delete(FileDescription file)
        {
            context.FileDescriptions.Find(file.Id).Enabled = false;
            context.SaveChanges();
            return file;
        }

        public FileDescription GetFile(Guid id)
        {
            return context.FileDescriptions.Find(id);
        }
    }
}
