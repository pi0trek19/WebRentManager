using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ClientFilesRepository : IClientFilesRepository
    {
        private readonly AppDbContext context;

        public ClientFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ClientFile Add(ClientFile file)
        {
            context.ClientFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public List<ClientFile> GetClientFiles(Guid id)
        {
            return context.ClientFile.Where(file => file.ClientId == id).ToList();
        }

        public ClientFile GetFile(Guid id)
        {
            return context.ClientFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }
    }
}
