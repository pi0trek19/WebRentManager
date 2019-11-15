using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarDamagesRepository
    {
        CarDamage Add(CarDamage damage);
        IEnumerable<CarDamage> GetCarDamages(Guid id);
        CarDamage GetCarDamage(Guid id);
        CarDamage Remove(CarDamage damage);
        CarDamage Update(CarDamage damageChanges);
    }
}
