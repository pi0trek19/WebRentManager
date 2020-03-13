using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarDamageFilesRepository : ICarDamageFilesRepository
    {
        private readonly AppDbContext context;

        public CarDamageFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CarDamageFile Add(CarDamageFile file)
        {
            context.CarDamageFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public List<CarDamageFile> GetCarDamageFiles(Guid id)
        {
            return context.CarDamageFile.Where(file => file.CarDamageId == id).ToList();
        }

        public CarDamageFile GetFile(Guid id)
        {
            return context.CarDamageFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }
    }
}
