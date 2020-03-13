using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarFilesRepository : ICarFilesRepository
    {
        private readonly AppDbContext context;

        public CarFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CarFile Add(CarFile file)
        {
            context.CarFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public List<CarFile> GetCarFiles(Guid id)
        {
            return context.CarFile.Where(file => file.CarId == id).ToList();
        }

        public CarFile GetFile(Guid id)
        {
            return context.CarFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }
    }
}
