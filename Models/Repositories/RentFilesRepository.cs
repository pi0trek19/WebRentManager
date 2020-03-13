using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class RentFilesRepository : IRentFilesRepository
    {
        private readonly AppDbContext context;

        public RentFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public RentFile Add(RentFile file)
        {
            context.RentFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public RentFile GetFile(Guid id)
        {
            return context.RentFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }

        public List<RentFile> GetRentFiles(Guid id)
        {
            return context.RentFile.Where(file => file.RentId == id).ToList();
        }
    }
}
