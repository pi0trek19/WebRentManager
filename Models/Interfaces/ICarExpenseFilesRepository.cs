using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarExpenseFilesRepository
    {
        CarExpenseFile Add(CarExpenseFile file);
        CarExpenseFile GetFile(Guid id);
        List<CarExpenseFile> GetCarExpenseFiles(Guid id);
    }
}
