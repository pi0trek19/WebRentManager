using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarFilesRepository
    {
        CarFile Add(CarFile file);
        CarFile GetFile(Guid id);
        List<CarFile> GetCarFiles(Guid id);
    }
}
