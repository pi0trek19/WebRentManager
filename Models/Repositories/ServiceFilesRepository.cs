using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ServiceFilesRepository : IServiceFilesRepository
    {
        private readonly AppDbContext context;

        public ServiceFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ServiceFile Add(ServiceFile file)
        {
            context.ServiceFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public ServiceFile GetFile(Guid id)
        {
            return context.ServiceFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }

        public List<ServiceFile> GetServiceFiles(Guid id)
        {
            return context.ServiceFile.Where(file => file.ServiceId == id).ToList();
        }
    }
}
