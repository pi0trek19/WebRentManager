using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarExpenseFilesRepository : ICarExpenseFilesRepository
    {
        private readonly AppDbContext context;

        public CarExpenseFilesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CarExpenseFile Add(CarExpenseFile file)
        {
            context.CarExpenseFile.Add(file);
            context.SaveChanges();
            return file;
        }

        public List<CarExpenseFile> GetCarExpenseFiles(Guid id)
        {
            return context.CarExpenseFile.Where(file => file.CarExpenseId == id).ToList();
        }

        public CarExpenseFile GetFile(Guid id)
        {
            return context.CarExpenseFile.FirstOrDefault(file => file.FileDescriptionId == id);
        }
    }
}
