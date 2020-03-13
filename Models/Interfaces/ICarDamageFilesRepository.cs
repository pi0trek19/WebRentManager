using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarDamageFilesRepository
    {
        CarDamageFile Add(CarDamageFile file);
        CarDamageFile GetFile(Guid id);
        List<CarDamageFile> GetCarDamageFiles(Guid id);
    }
}
